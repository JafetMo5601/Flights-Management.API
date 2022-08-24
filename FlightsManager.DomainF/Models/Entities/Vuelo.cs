using System.ComponentModel.DataAnnotations;

namespace FlightsManager.Domain.Models.Entities
{
    public class Vuelo
    {
        [Key]
        public int Id { get; set; }
        public Avion Avion { get; set; }
        
        [Required]
        public Aeropuerto AeropuertoPartida { get; set; }
        
        [Required]
        public Aeropuerto AeropuertoDestino { get; set; }

        public Horario Horario { get; set; }
        public Tarifa Tarifa { get; set; }


    }
}
