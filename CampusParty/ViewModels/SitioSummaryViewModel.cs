using CampusParty.Models;

namespace CampusParty.ViewModels {
    public class SitioSummaryViewModel {
        public IEnumerable<Sitio> Sitios { get; set; }
        public Pabellon Pabellon { get; set; }
    }
}
