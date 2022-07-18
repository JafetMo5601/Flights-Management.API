using System.ComponentModel.DataAnnotations;

namespace FlightsManager.Models.Vuelos
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
