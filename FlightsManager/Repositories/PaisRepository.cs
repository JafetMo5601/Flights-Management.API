using FlightsManager.DB;
using FlightsManager.Interfaces;
using FlightsManager.Models.Vuelos;
using Microsoft.EntityFrameworkCore;

namespace FlightsManager.Repositories
{
    public class PaisRepository : IPaisRepository
    {
        private readonly ApplicationDBContext _context;

        public PaisRepository(
            ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Pais>?> GetPaises()
        {
            var paises = await (from p in _context.Paises
                          select p).ToListAsync();

            if (paises.Any())
            {
                return paises;
            }
            return null;
        }

        public async Task<Pais?> GetPais(int paisId)
        {
            var pais = await (from p in _context.Paises
                        where p.Id == paisId
                        select p).FirstAsync();

            if (pais == null)
            {
                return null;
            }
            return pais;
        }

        public async Task<List<Pais>?> GetPaisesExcept(string paisName)
        {
            var paises = await (from p in _context.Paises
                                where p.Nombre != paisName
                                select p).ToListAsync();

            if (paises.Any())
            {
                return paises;
            }
            return null;
        }
    }
}
