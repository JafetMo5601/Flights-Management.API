namespace FlightsManager.Models.ViewModels
{
    public class InsertVuelo
    {
        public int IdAvion { get; set; }
        public int IdAeropuertoPartida { get; set; }
        public int IdAeropuertoDestino { get; set; }
        public int IdHorario { get; set; }
        public int IdTarifa { get; set; }
    }
}
