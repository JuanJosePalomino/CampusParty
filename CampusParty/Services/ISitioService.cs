using CampusParty.Models;

namespace CampusParty.Services {
    public interface ISitioService {
        public IEnumerable<Sitio> GetSitiosByPabellon(int idPabellon);
        public Sitio GetSitio(int idSitio);

        public IEnumerable<Sitio> GetSitios();
        public dynamic CreateSitio(Sitio sitio);
        public dynamic UpdateSitio(Sitio sitio);
        public dynamic DeleteSitio(int idSitio);
    }
}
