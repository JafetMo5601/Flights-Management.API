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

        public async Task<List<Vuelo>> GetAllVuelos()
        {
            var vuelos = await (from x in _context.Vuelos select x).ToListAsync();

            if (vuelos != null & vuelos.Count > 0)
            {
                return vuelos;
            }

            return null;
        }
    }
}
