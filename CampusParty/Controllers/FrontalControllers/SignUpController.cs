using CampusParty.Models;
using CampusParty.Services;
using Microsoft.AspNetCore.Mvc;

namespace CampusParty.Controllers.FrontalControllers {
    public class SignUpController : Controller {

        private readonly ICiudadService _ciudadService;
        public SignUpController(ICiudadService ciudadService) {
            _ciudadService = ciudadService;
        }
        public IActionResult Index() {
            IEnumerable<Ciudad> ciudades = _ciudadService.GetCiudades();
            return View(ciudades);
        }
    }
}
