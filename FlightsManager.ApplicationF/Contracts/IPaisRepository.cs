using FlightsManager.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightsManager.Application.Contracts
{
    public interface IPaisRepository
    {
        Task<Pais?> GetPais(int paisId);
        Task<List<Pais>?> GetPaises();
        Task<List<Pais>?> GetPaisesExcept(string paisName);
    }
}
