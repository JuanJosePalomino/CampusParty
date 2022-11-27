using CampusParty.Models;

namespace CampusParty.Services {
    public interface IUsuarioEventoService {
        public IEnumerable<UsuarioEvento> GetUsuarioEventosByUserId(int idUsuario);
        public IEnumerable<UsuarioEvento> GetUsuarioEventosByPabellon(int pabellonId);
        public IEnumerable<UsuarioEvento> GetUsuariosEvento();
        public UsuarioEvento GetUsuarioEvento(int usuarioEventoId);
        public dynamic DeleteUsuarioEvento(int usuarioEventoId);
    }
}
