using FlightsManager.Models.Vuelos;

namespace FlightsManager.Interfaces
{
    public interface IVuelosRepository
    {
        Task<List<Vuelo>?> GetAllVuelos();
        Task<Asiento?> GetAsientoById(int asientoId);
        Task<List<Asiento>?> GetAllAsientos();
        Task<Avion?> GetAvionById(int avionId);
        Task<List<Avion>?> GetAllAviones();
        Task<Aerolinea?> GetAerolineaById(int aerolineaId);
        Task<List<Aerolinea>?> GetAllAerolineas();
        Task<Aeropuerto?> GetAeropuertoById(int aeropuertoId);
        Task<List<Aeropuerto>?> GetAllAeropuertos();
        Task<Tarifa?> GetTarifaById(int tarifaId);
        Task<List<Tarifa>?> GetAllTarifas();
        Task<Horario?> GetHorarioId(int horarioId);
        Task<List<Horario>?> GetAllHorarios();
    }
}
