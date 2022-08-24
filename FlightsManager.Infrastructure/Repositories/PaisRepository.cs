using FlightsManager.Application.Contracts;
using FlightsManager.Domain.Models.Entities;
using FlightsManager.Infrastructure.DB;
using FlightsManager.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace FlightsManager.Infrastructure.Repositories
{
    public class PaisRepository : Repository<Pais>, IRepository<Pais>
    {
        //private readonly ApplicationDBContext _context;

        public PaisRepository(ApplicationDBContext context)
            : base(context)
        {

        }
        /*
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
        }*/
    }
}
