using CampusParty.Models;
using CampusParty.Services;
using CampusParty.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace CampusParty.Controllers.AdminControllers {
    public class SiteController : Controller {

        private readonly IPabellonService _pabellonService;
        private readonly ISitioService _sitioService;
        private readonly IUsuarioService _usuarioService;
        public SiteController(IPabellonService pabellonService,
            ISitioService sitioService,
            IUsuarioService usuarioService) {
            _pabellonService = pabellonService;
            _sitioService = sitioService;
            _usuarioService = usuarioService;
        }
        public IActionResult Index(int idPabellon) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    IEnumerable<Sitio> sitios = _sitioService.GetSitiosByPabellon(idPabellon);
                    Pabellon pabellon = _pabellonService.GetPabellon(idPabellon);
                    return View(new SitioSummaryViewModel {
                        Sitios = sitios,
                        Pabellon = pabellon
                    });
                }
                return RedirectToAction("Index", "Home");
            } catch (Exception ex) {
                return View();
            }
        }

        public IActionResult NewSite(int idPabellon) {
            Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
            if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                Pabellon pabellon = _pabellonService.GetPabellon(idPabellon);
                return View(pabellon);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SiteEditor(int idSitio) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    Sitio sitio = _sitioService.GetSitio(idSitio);
                    Pabellon pabellon = _pabellonService.GetPabellon(sitio.PabellonId);
                    return View(new SitioEditorViewModel {
                        Sitio = sitio,
                        Pabellon = pabellon
                    });
                }
                return RedirectToAction("Index", "Home");

            } catch (Exception ex) {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CreateSite(string request) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    Sitio sitio = JsonConvert.DeserializeObject<Sitio>(request);

                    dynamic result = _sitioService.CreateSitio(sitio);
                    string actionLink = Url.Action("Index", new { idPabellon = sitio.PabellonId });
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
        public IActionResult EditSite(string request) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    Sitio sitio = JsonConvert.DeserializeObject<Sitio>(request);

                    dynamic result = _sitioService.UpdateSitio(sitio);
                    string actionLink = Url.Action("Index", new { idPabellon = sitio.PabellonId });
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
        public IActionResult DeleteSite(int idSite, int idPabellon) {
            try {
                Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
                if (usuario != null && (usuario.Rol != null ? usuario.Rol.Nombre.Equals("Admin") : usuario.RolId == 1)) {
                    dynamic result = _sitioService.DeleteSitio(idSite);
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
