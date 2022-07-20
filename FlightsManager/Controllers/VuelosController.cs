using FlightsManager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        public VuelosController( IVuelosRepository vuelosRepository)
        {
            _vuelosRepository = vuelosRepository;
        }

        private readonly IVuelosRepository _vuelosRepository;

        [HttpGet]
        [Route("vuelos")]
        public async Task<IActionResult> GetVuelos()
        {
            try
            {
                var response = await _vuelosRepository.GetAllVuelos();

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
