using FlightsManager.Models.Vuelos;

namespace FlightsManager.Interfaces
{
    public interface IPaisRepository
    {
        Task<Pais> GetPais(int paisId);
    }
}
