using CampusParty.Models;
using CampusParty.Context;

namespace CampusParty.Services {
    public class EventoService : IEventoService {

        private readonly CampusPartyContext _context;
        public EventoService(CampusPartyContext context) {
            _context = context;
        }
        public IEnumerable<Evento> GetEventos() {
            try {
                return _context.Eventos.AsEnumerable();
            } catch (Exception ex) {
                return Enumerable.Empty<Evento>();
            }
        }
        public dynamic CreateEvento(Evento evento) {
            try {
                _context.Eventos.Add(evento);
                _context.SaveChanges();

                return new {
                    HasError = false
                };
            } catch (Exception ex) {
                return new {
                    HasError = true
                };
            }
        }
        public Evento GetEvento(int idEvento) {
            try {
                return _context.Eventos.FirstOrDefault(x => x.EventoId == idEvento);
            } catch (Exception ex) {
                return null;
            }
        }
        public dynamic DeleteEventos(int idEvento) {
            try {
                Evento evento = _context.Eventos.FirstOrDefault(x => x.EventoId == idEvento);

                if (evento != null) {
                    _context.Eventos.Remove(evento);
                    _context.SaveChanges();
                    return new {
                        HasError = false
                    };
                }
                return new {
                    HasError = true
                };
            } catch (Exception ex) {
                return new {
                    HasError = true
                };
            }
        }

        public dynamic UpdateEventos(Evento evento) {
            try {
                _context.Eventos.Update(evento);
                _context.SaveChanges();

                return new {
                    HasError = false
                };
            } catch (Exception ex) {
                return new {
                    HasError = true
                };
            }
        }
    }
}
