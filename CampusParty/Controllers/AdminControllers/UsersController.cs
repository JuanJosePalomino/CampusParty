using CampusParty.Models;
using CampusParty.Services;
using CampusParty.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CampusParty.Controllers.AdminControllers {
    public class UsersController : Controller {

        private readonly IUsuarioService _usuarioService;
        private readonly ICiudadService _ciudadService; 
        public UsersController(IUsuarioService usuarioService, ICiudadService ciudadService) {
            _usuarioService = usuarioService;
            _ciudadService = ciudadService;
        }
        public IActionResult Index() {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    IEnumerable<Usuario> usuarios = _usuarioService.GetUsuarios();
                    return View(usuarios);
                }
                return RedirectToAction("Index", "Home");
            } catch (Exception ex) {
                return View();
            }
        }

        public IActionResult UserDetails(int idUsuario) {
            try {
                Usuario authUser = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (authUser != null && (authUser.Rol != null ? authUser.Rol.Nombre.Equals("Admin") : authUser.RolId == 1)) {
                    Usuario usuario = _usuarioService.GetUsuario(idUsuario);
                    Ciudad ciudad = usuario != null ? _ciudadService.GetCiudad(usuario.CiudadId) : null;
                    Rol rol = usuario != null ? _usuarioService.GetRolById(usuario.RolId) : null;
                    return View(new UserDetailViewModel {
                        usuario = usuario,
                        ciudad = ciudad,
                        rol = rol
                    });
                }
                return RedirectToAction("Index", "Home");
            } catch (Exception ex) {
                return RedirectToAction("Index");
            }
        }

        [HttpDelete]
        public IActionResult DeleteUser(int idUsuario) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    dynamic result = _usuarioService.DeleteUsuario(idUsuario);
                    string actionLink = Url.Action("Index");
                    if (!result.HasError) {
                        return Json(new { hasError = result.HasError, actionLink = actionLink, status = HttpStatusCode.OK });
                    }

                    return Json(new { hasError = result.HasError, actionLink = actionLink, status = HttpStatusCode.BadRequest });
                }
                return Json(new { hasError = true, actionLink = Url.Action("Index", "Home"), status = HttpStatusCode.Unauthorized });
            } catch (Exception ex) {
                return RedirectToAction("Index");
            }

        }
    }
}
