using CampusParty.Context;
using CampusParty.Models;

namespace CampusParty.Services {
    public class UsuarioEventoService:IUsuarioEventoService {

        private readonly CampusPartyContext _context;

        public UsuarioEventoService(CampusPartyContext context) {
            _context = context;
        }
        public IEnumerable<UsuarioEvento> GetUsuarioEventosByUserId(int idUsuario) {
            try {
                return _context.UsuarioEventos.Where(x => x.UsuarioId == idUsuario);
            } catch (Exception ex) {
                return Enumerable.Empty<UsuarioEvento>();
            }
        }

        public UsuarioEvento GetUsuarioEvento(int usuarioEventoId) {
            try {
                return _context.UsuarioEventos.FirstOrDefault(x => x.UsuarioEventoId == usuarioEventoId);
            } catch (Exception ex) {
                return null;
            }
        }

        public dynamic DeleteUsuarioEvento(int usuarioEventoId) {
            try {
                UsuarioEvento usuarioEvento = _context.UsuarioEventos.FirstOrDefault(x => x.UsuarioEventoId == usuarioEventoId);

                if (usuarioEvento != null) {
                    _context.UsuarioEventos.Remove(usuarioEvento);
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

        public IEnumerable<UsuarioEvento> GetUsuarioEventosByPabellon(int pabellonId) {
            try {
                IEnumerable<int> sitiosByPabellon = _context.Sitios.Where(x => x.PabellonId == pabellonId).Select(x => x.SitioId);
                if (sitiosByPabellon != null && sitiosByPabellon.Any()) {
                    return _context.UsuarioEventos.Where(x => sitiosByPabellon.Contains(x.SitioId));
                }
                return Enumerable.Empty<UsuarioEvento>();
            } catch (Exception ex) {
                return Enumerable.Empty<UsuarioEvento>();
            }
        }

        public IEnumerable<UsuarioEvento> GetUsuariosEvento() {
            try {

                return _context.UsuarioEventos.AsEnumerable();
                
            } catch (Exception ex) {
                return Enumerable.Empty<UsuarioEvento>();
            }
        }
    }
}
