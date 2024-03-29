﻿

using System.ComponentModel.DataAnnotations;

namespace FlightsManager.Models.Vuelos
{
    public class Reservas
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El vuelo es requerido")]
        public Vuelo Vuelo { get; set; }

        [Required(ErrorMessage = "El pasajero es requerido")]
        public User Pasajero { get; set; }
    }
}
