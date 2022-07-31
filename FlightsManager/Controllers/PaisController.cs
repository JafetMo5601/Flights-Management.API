using FlightsManager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly IPaisRepository _paisRepository;

        public PaisController(IPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }

        [HttpGet]
        [Route("paises")]
        public async Task<IActionResult> GetVuelos()
        {
            try
            {
                var response = await _paisRepository.GetPaises();

                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un error en el servidor.");
            }
        }

        [HttpGet]
        [Route("paises-except")]
        public async Task<IActionResult> GetPaisesWithout(string nombrePais)
        {
            try
            {
                var response = await _paisRepository.GetPaisesExcept(nombrePais);

                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un error en el servidor.");
            }
        }


    }
}
