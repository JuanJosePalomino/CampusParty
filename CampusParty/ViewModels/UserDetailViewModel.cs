using CampusParty.Models;

namespace CampusParty.ViewModels {
    public class UserDetailViewModel {
        public Usuario usuario { get; set; }

        public Ciudad ciudad { get; set; }

        public Rol rol { get; set; }
    }
}
