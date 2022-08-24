using FlightsManager.Application.Contracts;
using FlightsManager.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace FlightsManager.Infrastructure.Repositories
{
    public class PagosRepository : IPagosRepository
    {
        public PagosRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        readonly ApplicationDBContext _context;

        /*
        public async Task<List<Reservas>?> GetAllPagos()
        {
            var reservas = await(from x in _context.Reservas select x)
                                .Include(x => x.Vuelo.Avion)
                                .Include(x => x.Vuelo.AeropuertoPartida)
                                .Include(x => x.Vuelo.AeropuertoDestino)
                                .Include(x => x.Vuelo.Horario)
                                .Include(x => x.Vuelo.Tarifa)
                                .Include(x => x.Pasajero.Country)
                                .ToListAsync();

            if (reservas.Any())
            {
                return reservas;
            }

            return null;
        }

        public async Task<Reservas?> GetPagoById(int reservaId)
        {
            var reserva = await(from a in _context.Reservas
                                where a.Id == reservaId
                                select a)
                                .Include(x => x.Vuelo.Avion)
                                .Include(x => x.Vuelo.AeropuertoPartida)
                                .Include(x => x.Vuelo.AeropuertoDestino)
                                .Include(x => x.Vuelo.Horario)
                                .Include(x => x.Vuelo.Tarifa)
                                .Include(x => x.Pasajero.Country)
                                .FirstAsync();

            if (reserva != null)
            {
                return reserva;
            }

            return null;
        }

        public async Task<Response> UpsertReserva(int vueloId, string pasajeroId, int reservaId = 0)
        {

            Vuelo? vuelo = await (from a in _context.Vuelos
                                 where a.Id == vueloId
                                 select a).FirstOrDefaultAsync();

            User? user = await (from a in _context.Users
                               where a.Id == pasajeroId
                               select a).FirstOrDefaultAsync();


            if (vuelo == null || user == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Parametros invalidos, no se ha podido realizar la transaccion."
                };
            }

            if (reservaId == 0)
            {
                try
                {
                    Reservas reserva = new Reservas
                    {
                        Vuelo = vuelo,
                        Pasajero = user
                    };

                    await _context.Reservas.AddAsync(reserva);
                }
                catch (Exception ex)
                {
                    return new Response
                    {
                        Status = "Error",
                        Message = "Creacion de reserva fallida: " + ex.Message
                    };
                }
            }
            else
            {
                try
                {
                    Reservas reserva = new Reservas
                    {
                        Id = reservaId,
                        Vuelo = vuelo,
                        Pasajero = user
                    };

                    _context.Reservas.Update(reserva);
                }
                catch(Exception ex)
                {
                    return new Response
                    {
                        Status = "Error",
                        Message = "Actualizacion de reserva fallida: " + ex.Message
                    };
                }      
            }

            await _context.SaveChangesAsync();

            return new Response { Status = "Success", Message = $"La reserva ha sido {(reservaId == 0 ? "creada" : "actualizada")} existosamente!" };
        }


        public async Task<Response> DeleteReserva(int reservaId)
        {
            var reserva = await(from a in _context.Reservas
                                 where a.Id == reservaId
                                 select a).FirstOrDefaultAsync();

            if (reserva == null)
            {
                return new Response { Status = "Error", Message = "No se ha encontrado el Id de la reserva." };
            }

            try
            {
                _context.Reservas.Remove(reserva);
            }
            catch(Exception ex)
            {
                return new Response { Status = "Error", 
                    Message = "Eliminacion de reserva fallida: " + ex.Message };
            }

            await _context.SaveChangesAsync();

            return new Response { Status = "Success", Message = "La reserva ha sido existosamente!" };
        }

        public async Task<List<Reservas>?> GetReservasbyVuelo(int vueloId)
        {
            var reservas = await(from a in _context.Reservas
                              where a.Vuelo.Id == vueloId
                              select a)
                               .Include(x => x.Vuelo)
                               .Include(x => x.Pasajero)
                               .ToListAsync();

            if (reservas != null)
            {
                return reservas;
            }

            return null; 
        }

        public async Task<List<Reservas>?> GetReservasbyUsuario(string userId)
        {
            var reservas = await(from a in _context.Reservas
                                 where a.Pasajero.UserId == userId
                                 select a)
                               .Include(x => x.Vuelo)
                               .Include(x => x.Pasajero)
                               .ToListAsync();

            if (reservas != null)
            {
                return reservas;
            }

            return null;

        }*/
    }
}
