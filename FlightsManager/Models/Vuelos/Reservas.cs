namespace FlightsManager.Models.Vuelos
{
    public class Reservas
    {
        public int Id { get; set; }
        public Vuelo Vuelo { get; set; }
        public User Pasajero { get; set; }
    }
}
