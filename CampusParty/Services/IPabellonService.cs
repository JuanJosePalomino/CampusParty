using CampusParty.Models;

namespace CampusParty.Services {
    public interface IPabellonService {

        public IEnumerable<Pabellon> GetPabellonesByEvento(int idEvento);
        public Pabellon GetPabellon(int idPabellon);
        public dynamic CreatePabellon(Pabellon pabellon);
        public dynamic UpdatePabellon(Pabellon pabellon);
        public dynamic DeletePabellon(int idPabellon);
    }
}
