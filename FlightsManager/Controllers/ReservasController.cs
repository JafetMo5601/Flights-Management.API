using FlightsManager.Interfaces;
using FlightsManager.Models.Vuelos;
using Microsoft.AspNetCore.Mvc;

namespace FlightsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        readonly IReservasRepository _reservasRepository;

        public ReservasController(IReservasRepository reservasRepository)
        {
            _reservasRepository = reservasRepository;
        }

        [HttpGet]
        [Route("reservas")]
        public async Task<IActionResult> GetReservas()
        {
            try
            {
                var response = await _reservasRepository.GetAllReservas();

                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un error en el servidor: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("reserva-id")]
        public async Task<IActionResult> GetReserva(int reservaId)
        {
            try
            {
                var response = await _reservasRepository.GetReservaById(reservaId);

                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un error en el servidor: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("reserva-upsert")]
        public async Task<IActionResult> UpsertReserva(int vueloId, string pasajeroId, int reservaId = 0)
        {
            var response = await _reservasRepository.UpsertReserva(vueloId, pasajeroId, reservaId);

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
        [Route("reserva-delete")]
        public async Task<IActionResult> DeleteReserva(int reservaId)
        {
            var response = await _reservasRepository.DeleteReserva(reservaId);

            if (response.Status == "Success")
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }


        [HttpGet]
        [Route("reserva-vuelo")]
        public async Task<IActionResult> GetReservasbyVuelo(int vueloId)
        {
            try
            {
                var response = await _reservasRepository.GetReservasbyVuelo(vueloId);

                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un error en el servidor: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("reserva-usuario")]
        public async Task<IActionResult> GetReservasbyUser(string userId)
        {
            try
            {
                var response = await _reservasRepository.GetReservasbyUsuario(userId);

                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un error en el servidor: " + ex.Message);
            }
        }
    }
}
