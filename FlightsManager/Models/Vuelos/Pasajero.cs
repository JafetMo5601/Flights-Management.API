using System.ComponentModel.DataAnnotations;

namespace FlightsManager.Models.Vuelos
{
    public class Pasajero
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        [Required]
        public string PrimerApellido { get; set; }

        [Required]
        public string SegundoApellido { get; set; }

        [Required]
        public int NumPasaporte { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Email { get; set; }

        public Pais Pais { get; set; }

    }
}
