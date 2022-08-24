using FlightsManager.Domain.Models;
using FlightsManager.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightsManager.Application.Contracts
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
