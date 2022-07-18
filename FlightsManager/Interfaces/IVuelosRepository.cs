using FlightsManager.Models.Vuelos;

namespace FlightsManager.Interfaces
{
    public interface IVuelosRepository
    {
        Task<List<Vuelo>> GetAllVuelos();
    }
}
