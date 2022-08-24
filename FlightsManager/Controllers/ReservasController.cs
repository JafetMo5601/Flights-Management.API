using FlightsManager.Application.Contracts;
using FlightsManager.Domain.Models.MailModels;
using FlightsManager.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using FlightsManager.Infrastructure.Repository;
using FlightsManager.Infrastructure.Repository.UnitOfWork;
using FlightsManager.Infrastructure.DB;

namespace FlightsManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        readonly ICartero Cartero;
        readonly IReservasRepository _reservasRepository;
        readonly IIdentityRepository _identityRepository;
        readonly IVuelosRepository _vuelosRepository;

        public ReservasController(ICartero cartero, IReservasRepository reservasRepository,
            IIdentityRepository identityRepository, IVuelosRepository vuelosRepository)
        {
            Cartero = cartero;
            _reservasRepository = reservasRepository;
            _identityRepository = identityRepository;
            _vuelosRepository = vuelosRepository;
        }

        [HttpGet]
        [Route("reservas")]
        public async Task<IActionResult> GetReservas()
        {
            try
            {
                var response = await _reservasRepository.GetAllReservas();
                //var response = _repositoryReservas.Listar(propiedadesIncluidas: "Vuelo.Avion,Vuelo.Horario ");

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
                var pasajero = await _identityRepository.GetUserInfo(pasajeroId);
                var vuelo = await _vuelosRepository.GetVueloById(vueloId);

                Cartero.Enviar
                    (
                        new CorreoElectronico
                        {
                            Destinatario = pasajero.Email,
                            Asunto = $"Reserva Confirmada Exitosamente - Vuelo {vuelo.Id}",
                            Cuerpo = $"Estimado(a) {pasajero.Name}, \nLe informamos que se ha confirmado exitosamente su reserva con los siguientes detalles: \n\n" +
                            $"Vuelo numero: {vuelo.Id} \n" +
                            $"Aerolinea: {vuelo.Avion.Aerolinea.Nombre} \n" +
                            $"Avion: {vuelo.Avion.Id} - {vuelo.Avion.Tipo} \n" +
                            $"Hora de partida: {vuelo.Horario.HoraPartida} \n" +
                            $"Pais de partida: {vuelo.AeropuertoPartida.Pais.Nombre}  \n" +
                            $"Aeropuerto de partida: {vuelo.AeropuertoPartida.Nombre}   \n" +
                            $"Hora de llegada: {vuelo.Horario.HoraLlegada}  \n" +
                            $"Pais de destino: {vuelo.AeropuertoDestino.Pais.Nombre}  \n" +
                            $"Aeropuerto de destino: {vuelo.AeropuertoDestino.Nombre}   \n\n" +
                            $"Gracias por preferirnos."
                        }
                    );

                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpDelete]
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

        [HttpGet]
        [Route("next-reserva-usuario")]
        public async Task<IActionResult> GetNextReservasbyUser(string userId)
        {
            try
            {
                var response = await _reservasRepository.GetNextReservasbyUsuario(userId);

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
        [Route("past-reserva-usuario")]
        public async Task<IActionResult> GetPastReservasbyUser(string userId)
        {
            try
            {
                var response = await _reservasRepository.GetPastReservasbyUsuario(userId);

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
