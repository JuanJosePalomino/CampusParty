using CampusParty.Models;
namespace CampusParty.ViewModels {
    public class UsuarioEventoSummaryViewModel {

        public IEnumerable<UsuarioEvento> UsuariosEvento { get; set; }

        public Pabellon Pabellon { get; set; }

    }
}
