using System.ComponentModel.DataAnnotations;

namespace FlightsManager.Domain.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "UserId es requerido")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Username es requerido")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Apellidos son requeridos")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Correo es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Numero de pasaporte es requerido")]
        public string PassportNumber { get; set; }

        [Required(ErrorMessage = "Telefono es requerido")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Contraseña es requerido")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Fecha de nacimiento requerida")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Pais de origen es requerido")]
        public int CountryId { get; set; }
    }
}
