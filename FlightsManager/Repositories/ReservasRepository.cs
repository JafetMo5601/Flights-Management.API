using FlightsManager.DB;
using FlightsManager.Interfaces;
using FlightsManager.Models;
using FlightsManager.Models.Vuelos;
using Microsoft.EntityFrameworkCore;

namespace FlightsManager.Repositories
{
    public class ReservasRepository : IReservasRepository
    {
        public ReservasRepository (ApplicationDBContext context)
        {
            _context = context;
        }

        readonly ApplicationDBContext _context;


        public async Task<List<Reservas>?> GetAllReservas()
        {
            var reservas = await(from x in _context.Reservas select x).ToListAsync();

            if (reservas.Any())
            {
                return reservas;
            }

            return null;
        }

        public async Task<Reservas?> GetReservaById(int reservaId)
        {
            var reserva = await(from a in _context.Reservas
                                where a.Id == reservaId
                                select a).FirstAsync();

            if (reserva != null)
            {
                return reserva;
            }

            return null;
        }

        public async Task<Response> UpsertReserva(Reservas reserva)
        {
            if (reserva.Id == 0)
            {
                try
                {
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

            return new Response { Status = "Success", Message = $"La reserva ha sido {(reserva.Id == 0 ? "creada" : "actualizada")} existosamente!" };
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

        }
    }
}
