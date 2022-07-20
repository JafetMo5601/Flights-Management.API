using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightsManager.Models.Vuelos
{
    public class Pais
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
