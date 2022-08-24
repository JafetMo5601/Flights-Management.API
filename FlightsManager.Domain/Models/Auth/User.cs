using FlightsManager.Domain.Models.Vuelos;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FlightsManager.Domain.Models
{
    public class User: IdentityUser
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string PassportNumber { get; set; }

        public Pais? Country { get; set; }
    }
}
