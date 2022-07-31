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

        [HttpGet]
        [Route("asiento")]
        public async Task<IActionResult> GetAsientoById(int asientoId)
        {
            try
            {
                var response = await _vuelosRepository.GetAsientoById(asientoId);

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
        [Route("avion")]
        public async Task<IActionResult> GetAvionById(int avionId)
        {
            try
            {
                var response = await _vuelosRepository.GetAvionById(avionId);

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
        [Route("aerolinea")]
        public async Task<IActionResult> GetAerolineaById(int aerolineaId)
        {
            try
            {
                var response = await _vuelosRepository.GetAerolineaById(aerolineaId);

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
        [Route("aeropuerto")]
        public async Task<IActionResult> GetAeropuestoById(int aeropuertoId)
        {
            try
            {
                var response = await _vuelosRepository.GetAeropuertoById(aeropuertoId);

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
        [Route("tarifa")]
        public async Task<IActionResult> GetTarifaById(int tarifaId)
        {
            try
            {
                var response = await _vuelosRepository.GetTarifaById(tarifaId);

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
        [Route("horarios")]
        public async Task<IActionResult> GetHorarios()
        {
            try
            {
                var response = await _vuelosRepository.GetAllHorarios();

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
        [Route("horario")]
        public async Task<IActionResult> GetHorarioById(int horarioId)
        {
            try
            {
                var response = await _vuelosRepository.GetHorarioId(horarioId);

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
