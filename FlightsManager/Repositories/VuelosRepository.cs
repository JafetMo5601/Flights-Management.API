using FlightsManager.DB;
using FlightsManager.Interfaces;
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
            var vuelos = await (from x in _context.Vuelos select x).ToListAsync();

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
    }
}
