using FlightsManager.DB;
using FlightsManager.Interfaces;
using FlightsManager.Models.Vuelos;

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

        public async Task<List<Pais>> GetPaises()
        {
            var paises = (from p in _context.Paises
                          select p).ToList();

            if (paises.Any())
            {
                return paises;
            } 
            return null;
        }

        public async Task<Pais> GetPais(int paisId)
        {
            var pais = (from p in _context.Paises
                        where p.Id == paisId
                        select p).First();

            if (pais == null)
            {
                return null;
            }
            return pais;
        }
    }
}
