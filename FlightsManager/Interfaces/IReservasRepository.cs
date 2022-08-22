using FlightsManager.Models;
using FlightsManager.Models.Vuelos;

namespace FlightsManager.Interfaces
{
    public interface IReservasRepository
    {
        Task<List<Reservas>?> GetAllReservas();
        Task<Reservas?> GetReservaById(int reservaId);
        Task<Response> UpsertReserva(int vueloId, string pasajeroId, int reservaId=0);
        Task<Response> DeleteReserva(int reservaId);
        Task<List<Reservas>?> GetReservasbyVuelo(int vueloId);
        Task<List<Reservas>?> GetReservasbyUsuario(string userId);
        Task<List<Reservas>?> GetNextReservasbyUsuario(string userId);
        Task<List<Reservas>?> GetPastReservasbyUsuario(string userId);
    }
}
