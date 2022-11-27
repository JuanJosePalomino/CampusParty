using CampusParty.Models;
using CampusParty.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace CampusParty.Controllers.AdminControllers {
    public class CityController : Controller {

        private readonly ICiudadService _ciudadService;
        private readonly IUsuarioService _usuarioService;
        public CityController(ICiudadService ciudadService, IUsuarioService usuarioService) {
            _ciudadService = ciudadService;
            _usuarioService = usuarioService;
        }
        public IActionResult Index() {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    IEnumerable<Ciudad> ciudades = _ciudadService.GetCiudades();
                    return View(ciudades);
                }
                return RedirectToAction("Index", "Home");
            } catch (Exception ex) {
                return View();
            }
        }

        public IActionResult NewCity() {
            Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
            if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }


        public IActionResult CityEditor(int idCiudad) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    Ciudad ciudad = _ciudadService.GetCiudad(idCiudad);

                    return View(ciudad);
                }

                return RedirectToAction("Index", "Home");

            } catch (Exception ex) {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult CreateCity(string request) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    Ciudad ciudad = JsonConvert.DeserializeObject<Ciudad>(request);

                    dynamic result = _ciudadService.CreateCiudad(ciudad);
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
        public IActionResult EditCity(string request) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    Ciudad ciudad = JsonConvert.DeserializeObject<Ciudad>(request);

                    dynamic result = _ciudadService.UpdateCiudad(ciudad);
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
        public IActionResult DeleteCity(int idCiudad) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    dynamic result = _ciudadService.DeleteCiudad(idCiudad);
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
