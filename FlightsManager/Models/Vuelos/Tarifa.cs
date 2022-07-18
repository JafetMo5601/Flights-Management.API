using System.ComponentModel.DataAnnotations;

namespace FlightsManager.Models.Vuelos
{
    public class Tarifa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Clase { get; set; }

        [Required]
        public float Precio { get; set; }

    }
}
