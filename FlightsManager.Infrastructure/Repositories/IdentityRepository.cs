using FlightsManager.Infrastructure.DB;
using FlightsManager.Application.Contracts;
using FlightsManager.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using FlightsManager.Application.Utils;
using FlightsManager.Infrastructure.Repository;
using FlightsManager.Domain.Models.Entities;
using FlightsManager.Infrastructure.Repository.UnitOfWork;

namespace FlightsManager.Infrastructure.Repositories
{
    public class IdentityRepository: IIdentityRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        //private IPaisRepository _paisRepository;
        readonly IRepository<Pais> _paisRepository;
        private readonly ApplicationDBContext _context;
        private AuthUtils _authUtils;

        public IdentityRepository(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            //IPaisRepository paisRepository,
            IUnitOfWork<ApplicationDBContext> unitOfWork,
            ApplicationDBContext context,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _paisRepository = unitOfWork.Repository<Pais>();
            _context = context;

            _authUtils = new AuthUtils(_userManager, _roleManager, _configuration);
        }

        public async Task<User> GetUserInfo(string userId)
        {
            var user = await (from u in _context.Users
                              where u.UserId == userId
                              select u).FirstOrDefaultAsync();

            if (user == null) 
            {
                return null;
            }
            return user;
        }

        public async Task<Response> RegisterNewUser(string Role, RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                return new Response { Status = "Error", Message = "Error al registrar un usuario, ya existe" };
            }

            //var country = await _paisRepository.GetPais(model.CountryId);
            var country = _paisRepository.Obtener(model.CountryId);
            if (country == null)
            {
                return new Response { Status = "Error", Message = "Error al registrar el pais no existe." };
            }

            User user = new()
            {
                UserId = model.Id,
                Name = model.Name,
                PhoneNumber = model.Phone,
                Lastname = model.Lastname,
                PassportNumber = model.PassportNumber,
                BirthDate = model.BirthDate,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Country = null,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            { 
                return new Response { Status = "Error", Message = "Creacion de usuario fallida, contraseña ocupa una mayuscula, un caracter especial, un numero y al menos debe ser de más de 8 caracteres de largo" };
            }

            await _authUtils.AssignRole(user, Role);

            return new Response { Status = "Success", Message = "Usuario creado existosamente!" };
        }

        public async Task<LoginResponse?> LoginUser(LoginModel model)
        {
            var userRoleStored = "";
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    Console.WriteLine(userRole);
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    userRoleStored = userRole;
                }

                var token = _authUtils.GetToken(authClaims);

                return new LoginResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                    Role = userRoleStored,
                    EmailConfirmed = user.EmailConfirmed,
                    UserId = user.UserId,
                };
            }
            return null;
        }
    }
}
