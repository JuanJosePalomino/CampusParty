using CampusParty.Models;

namespace CampusParty.Services {
    public interface IEventoService {

        public IEnumerable<Evento> GetEventos();
        public Evento GetEvento(int idEvento);
        public dynamic CreateEvento(Evento evento);
        public dynamic UpdateEventos(Evento evento);
        public dynamic DeleteEventos(int idEvento);

    }
}
