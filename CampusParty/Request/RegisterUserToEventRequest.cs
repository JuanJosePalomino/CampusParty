namespace CampusParty.Request {
    public class RegisterUserToEventRequest {
        public string Carpa { get; set; }
        public string Vehiculo { get; set; }
        //public virtual Sitio Sitio { get; set; }
        public string Computador { get; set; }
        public int PabellonId { get; set; }
        public bool Estadia { get; set; }
        public int EventoId { get; set; }
        public IEnumerable<int> Equipos { get; set; }
    }
}
