using System.ComponentModel.DataAnnotations;

namespace FlightsManager.Models.Vuelos
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public float Costo { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public string Observacion { get; set; }

    }
}
