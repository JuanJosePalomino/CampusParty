using CampusParty.Context;
using CampusParty.Models;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using DevOne.Security.Cryptography.BCrypt;

namespace CampusParty.Services {
    public class UsuarioService : IUsuarioService {

        private readonly CampusPartyContext _context;

        public UsuarioService(CampusPartyContext context) {
            _context = context;
        }
        public IEnumerable<Usuario> GetUsuarios() {
            try {
                return _context.Usuarios.AsEnumerable();
            } catch (Exception ex) {
                return Enumerable.Empty<Usuario>();
            }
        }
        public Usuario GetUsuario(int idUsuario) {
            try {
                return _context.Usuarios.FirstOrDefault(x => x.UsuarioId == idUsuario);
            } catch (Exception ex) {
                return null;
            }
        }

        public dynamic CreateUsuario(Usuario usuario) {
            try {
                if (!_context.Usuarios.Any(x => x.Correo.Equals(usuario.Correo))) {
                    Rol rol = GetRolByName("User");
                    usuario.RolId = rol != null ? rol.RolId : 0;
                    _context.Usuarios.Add(usuario);
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
        public dynamic DeleteUsuario(int idUsuario) {
            try {
                Usuario usuario = _context.Usuarios.FirstOrDefault(x => x.UsuarioId == idUsuario);

                if (usuario != null) {
                    _context.Usuarios.Remove(usuario);
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

        public Usuario GetAuthenticatedUser(HttpContext context) {
            try {
                string currentSerializedUser = context.Session.GetString("CurrentUser");
                if (currentSerializedUser != null) {
                    return JsonConvert.DeserializeObject<Usuario>(currentSerializedUser);
                }
                return null;
            }catch(Exception ex) {
                return null;
            }
        }

        public dynamic SetAuthenticatedUser(Usuario usuario, HttpContext context) {
            try {
                RemoveAuthenticatedUser(context);

                context.Session.SetString("CurrentUser", JsonConvert.SerializeObject(usuario));
                return new {
                    HasError = false
                };
            } catch (Exception ex) {
                return new {
                    HasError = true
                };
            }
        }
        
        public dynamic RemoveAuthenticatedUser(HttpContext context) {
            try {
                context.Session.Remove("CurrentUser");
                return new {
                    HasError = false
                };
            } catch (Exception ex) {
                return new {
                    HasError = true
                };
            }
        }
        public Usuario ValidateCredentials(string correo, string password) {
            try {
                Usuario usuario = _context.Usuarios.FirstOrDefault(x => x.Correo.Equals(correo));
                if (usuario != null) {
                    if (BCryptHelper.CheckPassword(password, usuario.Contraseña)) {
                        return usuario;
                    }
                }
                return null;
            }catch(Exception ex) {
                return null;
            }
        }

        public string EncryptPassword(string password) {
            string salt = BCryptHelper.GenerateSalt();
            var hash = BCryptHelper.HashPassword(password, salt);
            return hash;
        }

        private byte[] GetPasswordHash(string password) {
            byte [] data = Encoding.ASCII.GetBytes(password);
            data = new MD5CryptoServiceProvider().ComputeHash(data);
            return data;
        }

        private bool ValidatePassword(string password, string encryptedPassword) {
            byte [] targetPassword = GetPasswordHash(password);
            byte[] sourcePassword = Encoding.ASCII.GetBytes(encryptedPassword);

            return ComparePasswords(targetPassword, sourcePassword);
        }

        private bool ComparePasswords(byte[] targetPaswword, byte [] sourcePassword) {
            bool valid = false;
            if (targetPaswword.Length == sourcePassword.Length) {
                int i = 0;
                while ((i < targetPaswword.Length) && (targetPaswword [i] == sourcePassword [i])) {
                    i += 1;
                }
                if (i == targetPaswword.Length) {
                    valid = true;
                }
            }

            return valid;
        }

        public Rol GetRolById(int rolId) {
            try {
                return _context.Roles.FirstOrDefault(x => x.RolId == rolId);
            }catch(Exception ex) {
                return null;
            }
        }

        public Rol GetRolByName(string rolName) {
            try {
                return _context.Roles.FirstOrDefault(x => x.Nombre.Equals(rolName));
            } catch (Exception ex) {
                return null;
            }
        }

    }
}
