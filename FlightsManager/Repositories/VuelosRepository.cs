using FlightsManager.DB;
using FlightsManager.Interfaces;
using FlightsManager.Models;
using FlightsManager.Models.ViewModels;
using FlightsManager.Models.Vuelos;
using Microsoft.EntityFrameworkCore;

namespace FlightsManager.Repositories
{
    public class VuelosRepository : IVuelosRepository
    {
        public VuelosRepository (ApplicationDBContext context)
        {
            _context = context;
        }

        readonly ApplicationDBContext _context; 

        public async Task<List<Vuelo>?> GetAllVuelos()
        {
            var vuelos = await (from a in _context.Vuelos
                                select a)
                               .Include(x => x.Avion.Aerolinea)
                               .Include(x => x.Tarifa.Asiento)
                               .Include(x => x.Horario)
                               .Include(x => x.AeropuertoPartida.Pais)
                               .Include(x => x.AeropuertoDestino.Pais)
                               .ToListAsync();

            if (vuelos.Any())
            {
                return vuelos;
            }

            return null;
        }

        public async Task<List<Vuelo>?> GetFutureFlights()
        {
            var vuelos = await (from a in _context.Vuelos
                                where a.Horario.HoraPartida > DateTime.Now
                                select a)
                               .Include(x => x.Avion.Aerolinea)
                               .Include(x => x.Tarifa.Asiento)
                               .Include(x => x.Horario)
                               .Include(x => x.AeropuertoPartida.Pais)
                               .Include(x => x.AeropuertoDestino.Pais)
                               .ToListAsync();

            if (vuelos.Any())
            {
                return vuelos;
            }

            return null;
        }

        public async Task<Asiento?> GetAsientoById(int asientoId)
        {
            var asiento = await (from a in _context.Asientos
                                 where a.Id == asientoId
                                 select a).FirstAsync();

            if (asiento != null)
            {
                return asiento;
            }

            return null;
        }

        public async Task<List<Asiento>?> GetAllAsientos()
        {
            var asientos = await (from x in _context.Asientos 
                                  select x).ToListAsync();

            if (asientos != null && asientos.Any())
            {
                return asientos;
            }

            return null;
        }

        public async Task<Avion?> GetAvionById(int avionId)
        {
            var avion = await (from a in _context.Aviones
                               where a.Id == avionId
                               select a)
                               .Include(x => x.Aerolinea)
                               .FirstAsync();

            if (avion != null)
            {
                return avion;
            }

            return null;
        }

        public async Task<List<Avion>?> GetAllAviones()
        {
            var aviones = await (from x in _context.Aviones
                                 select x)
                                 .Include(x => x.Aerolinea)
                                 .ToListAsync();

            if (aviones != null && aviones.Any())
            {
                return aviones;
            }

            return null;
        }

        public async Task<Aerolinea?> GetAerolineaById(int aerolineaId)
        {
            var aerolinea = await (from a in _context.Aerolineas
                                   where a.Id == aerolineaId
                                   select a).FirstAsync();

            if (aerolinea != null)
            {
                return aerolinea;
            }

            return null;
        }

        public async Task<List<Aerolinea>?> GetAllAerolineas()
        {
            var aerolineas = await (from x in _context.Aerolineas select x).ToListAsync();

            if (aerolineas != null && aerolineas.Any())
            {
                return aerolineas;
            }

            return null;
        }

        public async Task<Aeropuerto?> GetAeropuertoById(int aeropuertoId)
        {
            var aeropuerto = await (from a in _context.Aeropuertos
                                    where a.Id == aeropuertoId
                                    select a)
                                    .Include(a => a.Pais)
                                    .FirstAsync();

            if (aeropuerto != null)
            {
                return aeropuerto;
            }

            return null;
        }

        public async Task<List<Aeropuerto>?> GetAllAeropuertos()
        {
            var aeropuertos = await (from x in _context.Aeropuertos 
                                     select x)
                                     .Include(a => a.Pais)
                                     .ToListAsync();

            if (aeropuertos != null && aeropuertos.Any())
            {
                return aeropuertos;
            }

            return null;
        }

        public async Task<Tarifa?> GetTarifaById(int tarifaId)
        {
            var tarifa = await (from a in _context.Tarifas
                                where a.Id == tarifaId
                                select a)
                                .Include(x => x.Asiento)
                                .FirstAsync();

            if (tarifa != null)
            {
                return tarifa;
            }

            return null;
        }

        public async Task<List<Tarifa>?> GetAllTarifas()
        {
            var tarifas = await (from x in _context.Tarifas 
                                 select x)
                                 .Include(x => x.Asiento)
                                 .ToListAsync();

            if (tarifas != null && tarifas.Any())
            {
                return tarifas;
            }

            return null;
        }

        public async Task<Horario?> GetHorarioId(int horarioId)
        {
            var horario = await (from h in _context.Horarios
                                where h.Id == horarioId
                                select h)
                                .FirstAsync();

            if (horario != null)
            {
                return horario;
            }

            return null;
        }

        public async Task<List<Horario>?> GetAllHorarios()
        {
            var horarios = await (from x in _context.Horarios
                                 select x)
                                 .ToListAsync();

            if (horarios != null && horarios.Any())
            {
                return horarios;
            }

            return null;
        }

        public async Task<Response> InsertVuelo(InsertVuelo model)
        {
            Avion? avion = await (from a in _context.Aviones
                                  where a.Id == model.IdAvion
                                  select a).FirstOrDefaultAsync();

            Aeropuerto? aeropuertoPartida = await (from a in _context.Aeropuertos
                                                   where a.Id == model.IdAeropuertoPartida
                                                   select a).FirstOrDefaultAsync();

            Aeropuerto? aeropuertoDestino = await (from a in _context.Aeropuertos
                                                   where a.Id == model.IdAeropuertoDestino
                                                   select a).FirstOrDefaultAsync();

            Horario? horario = await (from a in _context.Horarios
                                  where a.Id == model.IdHorario
                                  select a).FirstOrDefaultAsync();

            Tarifa? tarifa = await (from a in _context.Tarifas
                                  where a.Id == model.IdTarifa
                                  select a).FirstOrDefaultAsync();

            if (avion == null || aeropuertoPartida == null ||
                aeropuertoDestino == null || horario == null || tarifa == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Parametros invalidos, no se ha podido realizar la transaccion."
                };
            }

            try
            {
                Vuelo vuelo = new Vuelo()
                {
                    Avion = avion,
                    AeropuertoDestino = aeropuertoDestino,
                    AeropuertoPartida = aeropuertoPartida,
                    Horario = horario,
                    Tarifa = tarifa
                };

                await _context.Vuelos.AddAsync(vuelo);
                await _context.SaveChangesAsync();

                return new Response { Status = "Success", Message = "El vuelo ha sido creado existosamente!" };
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
    }
}
