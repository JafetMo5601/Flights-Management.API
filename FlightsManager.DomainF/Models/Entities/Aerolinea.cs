using System.ComponentModel.DataAnnotations;

namespace FlightsManager.Domain.Models.Entities
{
    public class Aerolinea
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

    }
}
