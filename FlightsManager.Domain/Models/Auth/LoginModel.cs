using System.ComponentModel.DataAnnotations;

namespace FlightsManager.Domain.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Usuario es requerido")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Contraseña es requerido")]
        public string? Password { get; set; }
    }
}
