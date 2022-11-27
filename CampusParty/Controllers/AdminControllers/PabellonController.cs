using CampusParty.Models;
using CampusParty.Services;
using CampusParty.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace CampusParty.Controllers.AdminControllers {
    public class PabellonController : Controller {

        private readonly IPabellonService _pabellonService;
        private readonly IEventoService _eventoService;
        private readonly IUsuarioService _usuarioService;
        public PabellonController(IPabellonService pabellonService,
            IEventoService eventoService,
            IUsuarioService usuarioService) {
            _pabellonService = pabellonService;
            _eventoService = eventoService;
            _usuarioService = usuarioService;
        }

        public IActionResult Index(int idEvento) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    IEnumerable<Pabellon> pabellones = _pabellonService.GetPabellonesByEvento(idEvento);
                    Evento evento = _eventoService.GetEvento(idEvento);
                    return View(new PabellonSummaryViewModel {
                        Evento = evento,
                        Pabellones = pabellones
                    });
                }
                return RedirectToAction("Index", "Home");
            } catch (Exception ex) {
                return View();
            }
        }

        public IActionResult NewPabellon(int idEvento) {
            Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
            if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                Evento evento = _eventoService.GetEvento(idEvento);
                return View(evento);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult PabellonEditor(int idPabellon) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    Pabellon pabellon = _pabellonService.GetPabellon(idPabellon);
                    Evento evento = _eventoService.GetEvento(pabellon.EventoId);
                    return View(new PabellonEditorViewModel {
                        Pabellon = pabellon,
                        Evento = evento
                    });
                }
                return RedirectToAction("Index", "Home");

            } catch (Exception ex) {
                return RedirectToAction("Index");
            }
        }

        public IActionResult PabellonSites() {
            Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
            if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult CreatePabellon(string request) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    Pabellon pabellon = JsonConvert.DeserializeObject<Pabellon>(request);

                    dynamic result = _pabellonService.CreatePabellon(pabellon);
                    string actionLink = Url.Action("Index", new { idEvento = pabellon.EventoId });
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

        [HttpPut]
        public IActionResult EditPabellon(string request) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    Pabellon pabellon = JsonConvert.DeserializeObject<Pabellon>(request);

                    dynamic result = _pabellonService.UpdatePabellon(pabellon);
                    string actionLink = Url.Action("Index", new { idEvento = pabellon.EventoId });
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

        [HttpDelete]
        public IActionResult DeletePabellon(int idPabellon, int idEvento) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    dynamic result = _pabellonService.DeletePabellon(idPabellon);
                    string actionLink = Url.Action("Index", new { idEvento = idEvento });
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
