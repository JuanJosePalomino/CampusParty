using CampusParty.Models;

namespace CampusParty.ViewModels {
    public class PabellonSummaryViewModel {

        public IEnumerable<Pabellon> Pabellones { get; set; }
        public Evento Evento { get; set; }

    }
}
