using FlightsManager.Application.Contracts;
using FlightsManager.Domain.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightsManager.API.Controllers
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
        [Route("next-vuelos")]
        public async Task<IActionResult> GetFutureVuelos()
        {
            try
            {
                var response = await _vuelosRepository.GetFutureFlights();

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
        [Route("asientos")]
        public async Task<IActionResult> GetAsientos()
        {
            try
            {
                var response = await _vuelosRepository.GetAllAsientos();

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
        [Route("aviones")]
        public async Task<IActionResult> GetAviones()
        {
            try
            {
                var response = await _vuelosRepository.GetAllAviones();

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
        [Route("aerolineas")]
        public async Task<IActionResult> GetAerolineas()
        {
            try
            {
                var response = await _vuelosRepository.GetAllAerolineas();

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
        [Route("aeropuertos")]
        public async Task<IActionResult> GetAeropuertos()
        {
            try
            {
                var response = await _vuelosRepository.GetAllAeropuertos();

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
        [Route("tarifas")]
        public async Task<IActionResult> GetTarifas()
        {
            try
            {
                var response = await _vuelosRepository.GetAllTarifas();

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

        [HttpGet]
        [Route("vuelo-id")]
        public async Task<IActionResult> GetVueloById(int vueloId)
        {
            try
            {
                var response = await _vuelosRepository.GetVueloById(vueloId);

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


        [HttpPost]
        [Route("vuelo")]
        public async Task<IActionResult> CreateVuelo(InsertVuelo model)
        {
            try
            {
                var response = await _vuelosRepository.InsertVuelo(model);

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
        [Route("airport-except")]
        public async Task<IActionResult> GetAirportsWithout(string airportName)
        {
            try
            {
                var response = await _vuelosRepository.GetAirportExcept(airportName);

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
