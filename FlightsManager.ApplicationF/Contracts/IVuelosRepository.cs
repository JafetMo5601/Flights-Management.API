using FlightsManager.Domain.Models;
using FlightsManager.Domain.Models.ViewModels;
using FlightsManager.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightsManager.Application.Contracts
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
        Task<Response> InsertVuelo(InsertVuelo model);
        Task<List<Vuelo>?> GetFutureFlights();
        Task<Vuelo> GetVueloById(int vueloId);
        Task<List<Aeropuerto>> GetAirportExcept(string airportName);
    }
}
