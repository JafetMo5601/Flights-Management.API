using System.ComponentModel.DataAnnotations;

namespace FlightsManager.Domain.Models.Entities
{
    public class Avion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Fabricante { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public int Capacidad { get; set; }

        public Aerolinea Aerolinea { get; set; }

    }
}
