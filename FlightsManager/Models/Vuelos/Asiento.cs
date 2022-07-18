﻿using System.ComponentModel.DataAnnotations;

namespace FlightsManager.Models.Vuelos
{
    public class Asiento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Letra { get; set; }

        [Required]
        public int Fila { get; set; }

    }
}
