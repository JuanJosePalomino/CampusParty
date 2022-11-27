using CampusParty.Context;
using CampusParty.Models;

namespace CampusParty.Services {
    public class CiudadService : ICiudadService {

        private readonly CampusPartyContext _context;
        public CiudadService(CampusPartyContext context) {
            _context = context;
        }
        public IEnumerable<Ciudad> GetCiudades() {
            try {
                return _context.Ciudades.AsEnumerable();
            } catch (Exception ex) {
                return Enumerable.Empty<Ciudad>();
            }
        }

        public Ciudad GetCiudad(int idCiudad) {
            try {
                return _context.Ciudades.FirstOrDefault(x => x.CiudadId == idCiudad);
            } catch (Exception ex) {
                return null;
            }
        }
        public dynamic CreateCiudad(Ciudad ciudad) {
            try {
                _context.Ciudades.Add(ciudad);
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

        public dynamic DeleteCiudad(int idCiudad) {
            try {
                Ciudad ciudad = _context.Ciudades.FirstOrDefault(x => x.CiudadId == idCiudad);

                if (ciudad != null) {
                    _context.Ciudades.Remove(ciudad);
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

        public dynamic UpdateCiudad(Ciudad ciudad) {
            try {
                _context.Ciudades.Update(ciudad);
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
    }
}
