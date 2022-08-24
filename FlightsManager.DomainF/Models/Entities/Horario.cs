using System;

namespace FlightsManager.Domain.Models.Entities
{
    public class Horario
    {
        public int Id { get; set; }
        public DateTime HoraPartida { get; set; }
        public DateTime HoraLlegada { get; set; }
    }
}
