﻿using FlightsManager.Models;
using FlightsManager.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlightsManager.Utils
{
    public class AuthUtils
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthUtils(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        private string getRole(string role)
        {
            if (role.ToLower() == "admin") { return UserRoles.Admin; }
            else { return UserRoles.User; }

        }

        public async Task AssignRole(User userToAssignRole, string roleToAssign)
        {
            if (!await _roleManager.RoleExistsAsync(getRole(roleToAssign)))
            {
                await _roleManager.CreateAsync(new IdentityRole(getRole(roleToAssign)));
            }
            await _userManager.AddToRoleAsync(userToAssignRole, getRole(roleToAssign));
        }

        public JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
