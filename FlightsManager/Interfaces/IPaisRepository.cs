using FlightsManager.Models.Vuelos;

namespace FlightsManager.Interfaces
{
    public interface IPaisRepository
    {
        Task<Pais?> GetPais(int paisId);
        Task<List<Pais>?> GetPaises();
        Task<List<Pais>?> GetPaisesExcept(string paisName);
    }
}
