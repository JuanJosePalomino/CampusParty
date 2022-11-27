using CampusParty.Context;
using CampusParty.Models;

namespace CampusParty.Services {
    public class EquipoService : IEquipoService {

        private readonly CampusPartyContext _context;
        public EquipoService(CampusPartyContext context) {
            _context = context;
        }
        public IEnumerable<Equipo> GetEquipos() {
            try {
                return _context.Equipos.AsEnumerable();
            } catch (Exception ex) {
                return Enumerable.Empty<Equipo>();
            }
        }
        public Equipo GetEquipo(int idEquipo) {
            try {
                return _context.Equipos.FirstOrDefault(x => x.EquipoId == idEquipo);
            } catch (Exception ex) {
                return null;
            }
        }
        public dynamic CreateEquipo(Equipo equipo) {
            try {
                _context.Equipos.Add(equipo);
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
        public dynamic UpdateEquipo(Equipo equipo) {
            try {
                _context.Equipos.Update(equipo);
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
        public dynamic DeleteEquipo(int idEquipo) {
            try {
                Equipo equipo = _context.Equipos.FirstOrDefault(x => x.EquipoId == idEquipo);

                if (equipo != null) {
                    _context.Equipos.Remove(equipo);
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
