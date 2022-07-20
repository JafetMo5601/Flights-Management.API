using System.ComponentModel.DataAnnotations;

namespace FlightsManager.Models.Vuelos
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public float Monto { get; set; }

        [Required]
        public string TipoComprobante { get; set; }

        [Required]
        public int NumComprobante { get; set; }

        [Required]
        public float Impuesto { get; set; }

        public Reserva Reserva { get; set; }

        public User Pasajero { get; set; }
        public Pais Pais { get; set; }

    }
}
