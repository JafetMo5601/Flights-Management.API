using System.ComponentModel.DataAnnotations;

namespace FlightsManager.Domain.Models.Entities
{
    public class Tarifa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Clase { get; set; }

        [Required]
        public float Precio { get; set; }

        [Required]
        public Asiento Asiento { get; set; }
    }
}
