using System.ComponentModel.DataAnnotations;

namespace FlightsManager.Domain.Models.Entities
{
    public class Aeropuerto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public Pais Pais { get; set; }
    }
}
