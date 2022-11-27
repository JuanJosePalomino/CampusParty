using CampusParty.Models;
using CampusParty.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace CampusParty.Controllers.AdminControllers {
    public class EventController : Controller {

        private readonly IEventoService _eventoService;
        private readonly IUsuarioService _usuarioService;
        public EventController(IEventoService eventoService,
            IUsuarioService usuarioService) {
            _eventoService = eventoService;
            _usuarioService = usuarioService;
        }
        public IActionResult Index() {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);

                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    IEnumerable<Evento> eventos = _eventoService.GetEventos();
                    return View(eventos);
                }

                return RedirectToAction("Index", "Home");

            } catch (Exception ex) {
                return View();
            }
            
        }

        public IActionResult NewEvent() {
            Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
            if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        
        public IActionResult EventEditor(int idEvento) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    Evento evento = _eventoService.GetEvento(idEvento);

                    return View(evento);
                }

                return RedirectToAction("Index", "Home");

            } catch (Exception ex) {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult CreateEvent(string request) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    Evento evento = JsonConvert.DeserializeObject<Evento>(request);
                    dynamic result = _eventoService.CreateEvento(evento);
                    string actionLink = Url.Action("Index");
                    if (!result.HasError) {
                        return Json(new { hasError = result.HasError, actionLink = actionLink, status = HttpStatusCode.OK });
                    }

                    return Json(new { hasError = result.HasError, actionLink = actionLink, status = HttpStatusCode.BadRequest });
                }
                return Json(new { hasError = true , actionLink = Url.Action("Index", "Home"), status = HttpStatusCode.Unauthorized });

            } catch(Exception ex) {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPut]
        public IActionResult EditEvent(string request) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if(usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    Evento evento = JsonConvert.DeserializeObject<Evento>(request);

                    dynamic result = _eventoService.UpdateEventos(evento);
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

        [HttpDelete]
        public IActionResult DeleteEvent(int idEvento) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    dynamic result = _eventoService.DeleteEventos(idEvento);
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
