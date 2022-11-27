using CampusParty.Models;
using CampusParty.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace CampusParty.Controllers.AdminControllers {
    public class TeamController : Controller {

        private readonly IEquipoService _equipoService;
        private readonly IUsuarioService _usuarioService;
        public TeamController(IEquipoService equipoService,
            IUsuarioService usuarioService) {
            _equipoService = equipoService;
            _usuarioService = usuarioService;
        }
        public IActionResult Index() {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    IEnumerable<Equipo> equipos = _equipoService.GetEquipos();
                    return View(equipos);
                }
                return RedirectToAction("Index", "Home");

            } catch (Exception ex) {
                return View();
            }
        }

        public IActionResult NewTeam() {
            Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
            if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult TeamEditor(int idEquipo) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    Equipo equipo = _equipoService.GetEquipo(idEquipo);

                    return View(equipo);
                }
                return RedirectToAction("Index", "Home");
            } catch (Exception ex) {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CreateTeam(string request) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    Equipo equipo = JsonConvert.DeserializeObject<Equipo>(request);

                    dynamic result = _equipoService.CreateEquipo(equipo);
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

        [HttpPut]
        public IActionResult EditTeam(string request) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    Equipo equipo = JsonConvert.DeserializeObject<Equipo>(request);

                    dynamic result = _equipoService.UpdateEquipo(equipo);
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
        public IActionResult DeleteTeam(int idEquipo) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    dynamic result = _equipoService.DeleteEquipo(idEquipo);
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
