using CampusParty.Models;
using CampusParty.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace CampusParty.Controllers.FrontalControllers {
    public class AuthController : Controller {

        private readonly IUsuarioService _usuarioService;
        public AuthController(IUsuarioService usuarioService) {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Register(string request) {
            try {
                Usuario usuario = JsonConvert.DeserializeObject<Usuario>(request);
                usuario.Contraseña = _usuarioService.EncryptPassword(usuario.Contraseña);
                dynamic result = _usuarioService.CreateUsuario(usuario);
                string actionLink = Url.Action("Index", "Home");
                if (!result.HasError) {
                    _usuarioService.SetAuthenticatedUser(usuario, HttpContext);
                    return Json(new { hasError = result.HasError, actionLink = actionLink, status = HttpStatusCode.OK });
                }

                return Json(new { hasError = result.HasError, actionLink = actionLink, status = HttpStatusCode.BadRequest });
            } catch (Exception ex) {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult SignIn(string correo, string password) {
            try {
                Usuario usuario = _usuarioService.ValidateCredentials(correo, password);
                string actionLink = Url.Action("Index", "Home");
                if (usuario != null) {
                    dynamic result = _usuarioService.SetAuthenticatedUser(usuario, HttpContext);
                    if (!result.HasError) {
                        return Json(new { status = HttpStatusCode.OK, actionLink = actionLink });
                    }
                }
                return Json(new { status = HttpStatusCode.BadRequest, actionLink = actionLink });
            } catch (Exception ex) {
                return Json(new { status = HttpStatusCode.InternalServerError });
            }
        }

        [HttpPost]
        public IActionResult LogOut() {
            try {
                dynamic result = _usuarioService.RemoveAuthenticatedUser(HttpContext);
                string actionLink = Url.Action("Index", "Home");
                if (!result.HasError) {
                    return Json(new { status = HttpStatusCode.OK, actionLink = actionLink });
                }
                return Json(new { status = HttpStatusCode.BadRequest, actionLink = actionLink });
            } catch (Exception ex) {
                return Json(new { status = HttpStatusCode.InternalServerError});
            }
        }

    }
}
