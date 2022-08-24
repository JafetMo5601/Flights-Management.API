using FlightsManager.Application.Contracts;
using FlightsManager.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightsManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IConfiguration _Configuration;

        public AuthController(
            IIdentityRepository identityRepository,
            IConfiguration configuration)
        {
            _identityRepository = identityRepository;
            _Configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var response = await _identityRepository.LoginUser(model);

            if (response == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var response = await _identityRepository.RegisterNewUser("User", model);

            if (response.Status == "Success")
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var response = await _identityRepository.RegisterNewUser("Admin", model);

            try
            {
                if (response.Status == "Success")
                {
                    return Ok(response);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error en el servidor al registrar el administrador, contacte a los desarrolladores.");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        [HttpGet]
        [Route("user-info")]
        public async Task<IActionResult> GetUserInfo(string userId)
        {
            var response = await _identityRepository.GetUserInfo(userId);

            try
            {
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error en el servidor al registrar el administrador, contacte a los desarrolladores.");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }
}
