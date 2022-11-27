using Microsoft.AspNetCore.Mvc;
using CampusParty.Services;
using CampusParty.Models;
using CampusParty.ViewModels;
using System.Net;

namespace CampusParty.Controllers.AdminControllers {
    public class UsersEventController : Controller {

        private readonly IUsuarioEventoService _usuarioEventoService;
        private readonly IUsuarioService _usuarioService;
        private readonly IPabellonService _pabellonService;
        public UsersEventController(IUsuarioEventoService usuarioEventoService,
            IUsuarioService usuarioService,
            IPabellonService pabellonService) {
            _usuarioEventoService = usuarioEventoService;
            _usuarioService = usuarioService;
            _pabellonService = pabellonService;
        }
        public IActionResult Index(int idPabellon) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    Pabellon pabellon = _pabellonService.GetPabellon(idPabellon);
                    IEnumerable<UsuarioEvento> usuariosEvento = _usuarioEventoService.GetUsuarioEventosByPabellon(idPabellon);
                    return View(new UsuarioEventoSummaryViewModel {
                        UsuariosEvento = usuariosEvento,
                        Pabellon = pabellon
                    });
                }
                return RedirectToAction("Index", "Home");
            } catch (Exception ex) {
                return View();
            }
        }

        public IActionResult UserEventDetail(int idUsuarioEvento) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    UsuarioEvento usuarioEvento = _usuarioEventoService.GetUsuarioEvento(idUsuarioEvento);
                    return View(usuarioEvento);
                }
                return RedirectToAction("Index", "Home");

            } catch (Exception ex) {
                return RedirectToAction("Index");
            }
        }

        [HttpDelete]
        public IActionResult DeleteUserEvent(int idUsuarioEvento, int idPabellon) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    dynamic result = _usuarioEventoService.DeleteUsuarioEvento(idUsuarioEvento);
                    string actionLink = Url.Action("Index", new { idPabellon = idPabellon });
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
