using Microsoft.AspNetCore.Mvc;

namespace CampusParty.Controllers.FrontalControllers {
    public class SignInController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
