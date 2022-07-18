using System.ComponentModel.DataAnnotations;

namespace FlightsManager.Models.Vuelos
{
    public class Vuelo
    {
        [Key]
        public int Id { get; set; }

        public Avion Avion { get; set; }

        public Asiento Asiento { get; set; }

        public Tarifa Tarifa { get; set; }

        public Reserva Reserva { get; set; }


    }
}
