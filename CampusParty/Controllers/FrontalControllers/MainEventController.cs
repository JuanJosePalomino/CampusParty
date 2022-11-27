using CampusParty.Context;
using CampusParty.Request;
using CampusParty.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using CampusParty.Services;

namespace CampusParty.Controllers.FrontalControllers {
    public class MainEventController : Controller {

        private readonly CampusPartyContext _context;
        private readonly IUsuarioService _usuarioService; 

        public MainEventController(CampusPartyContext context, IUsuarioService usuarioService) {
            _context = context;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult RegisterUserToEvent(string request) {
            RegisterUserToEventRequest registerUserToEventRequest = JsonConvert.DeserializeObject<RegisterUserToEventRequest>(request);

            Sitio sitio = _context.Sitios.FirstOrDefault(x => x.PabellonId == registerUserToEventRequest.PabellonId && x.Estado);
            Usuario usuario = _usuarioService.GetAuthenticatedUser(HttpContext);
            IEnumerable<Equipo> equipos = _context.Equipos.Where(x => registerUserToEventRequest.Equipos.Contains(x.EquipoId));

            if (sitio != null && usuario != null) {
                UsuarioEvento usuarioEvento = new UsuarioEvento {
                    Carpa = registerUserToEventRequest.Carpa,
                    Computador = registerUserToEventRequest.Computador,
                    UsuarioId = usuario.UsuarioId,
                    Vehiculo = registerUserToEventRequest.Vehiculo,
                    SitioId = sitio.SitioId,
                    EventoId = registerUserToEventRequest.EventoId,
                    Estadia = registerUserToEventRequest.Estadia
                    
                };

                _context.UsuarioEventos.Add(usuarioEvento);
                _context.SaveChanges();
            }

            string actionLink = Url.Action("Index","Home");
            return Json(new { hasError = false, actionLink = actionLink, status = HttpStatusCode.OK });
        }
    }
}
