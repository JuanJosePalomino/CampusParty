using CampusParty.Context;
using CampusParty.Models;

namespace CampusParty.Services {
    public class SitioService : ISitioService {

        private readonly CampusPartyContext _context;
        public SitioService(CampusPartyContext context) {
            _context = context;
        }

        public IEnumerable<Sitio> GetSitiosByPabellon(int idPabellon) {
            try {
                return _context.Sitios.Where(x => x.PabellonId == idPabellon);
            } catch (Exception ex) {
                return Enumerable.Empty<Sitio>();
            }
        }

        public IEnumerable<Sitio> GetSitios() {
            try {
                return _context.Sitios.AsEnumerable();
            } catch (Exception ex) {
                return Enumerable.Empty<Sitio>();
            }
        }
        public Sitio GetSitio(int idSitio) {
            try {
                return _context.Sitios.FirstOrDefault(x => x.SitioId == idSitio);
            } catch (Exception ex) {
                return null;
            }
        }
        public dynamic CreateSitio(Sitio sitio) {
            try {
                _context.Sitios.Add(sitio);
                _context.SaveChanges();

                return new {
                    HasError = false
                };
            } catch (Exception ex) {
                return new {
                    HasError = true
                };
            }
        }
        public dynamic UpdateSitio(Sitio sitio) {
            try {
                _context.Sitios.Update(sitio);
                _context.SaveChanges();

                return new {
                    HasError = false
                };
            } catch (Exception ex) {
                return new {
                    HasError = true
                };
            }
        }
        public dynamic DeleteSitio(int idSitio) {
            try {
                Sitio sitio = _context.Sitios.FirstOrDefault(x => x.SitioId == idSitio);

                if (sitio != null) {
                    _context.Sitios.Remove(sitio);
                    _context.SaveChanges();
                    return new {
                        HasError = false
                    };
                }
                return new {
                    HasError = true
                };
            } catch (Exception ex) {
                return new {
                    HasError = true
                };
            }
        }





    }
}
