using CampusParty.Models;

namespace CampusParty.Services {
    public interface ICiudadService {

        public IEnumerable<Ciudad> GetCiudades();
        public Ciudad GetCiudad(int idCiudad);
        public dynamic CreateCiudad(Ciudad ciudad);
        public dynamic UpdateCiudad(Ciudad ciudad);
        public dynamic DeleteCiudad(int idCiudad);
    }
}
