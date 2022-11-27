using CampusParty.Models;

namespace CampusParty.Services {
    public interface IUsuarioService {

        public IEnumerable<Usuario> GetUsuarios();
        public Usuario GetUsuario(int idUsuario);
        public dynamic CreateUsuario(Usuario evento);
        public dynamic DeleteUsuario(int idUsuario);
        public Usuario GetAuthenticatedUser(HttpContext context);
        public dynamic SetAuthenticatedUser(Usuario usuario, HttpContext context);
        public dynamic RemoveAuthenticatedUser(HttpContext context);
        public Usuario ValidateCredentials(string correo, string password);
        public string EncryptPassword(string password);
        public Rol GetRolById(int rolId);
        public Rol GetRolByName(string rolName);
    }
}
