using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightsManager.Domain.Models.Entities
{
    public class Pais
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
