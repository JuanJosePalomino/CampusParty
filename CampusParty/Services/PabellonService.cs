using CampusParty.Context;
using CampusParty.Models;

namespace CampusParty.Services {
    public class PabellonService : IPabellonService {

        private readonly CampusPartyContext _context;

        public PabellonService(CampusPartyContext context) {
            _context = context;
        }
        public IEnumerable<Pabellon> GetPabellonesByEvento(int idEvento) {
            try {
                return _context.Pabellones.Where(x => x.EventoId == idEvento);
            }catch(Exception ex) {
                return Enumerable.Empty<Pabellon>();
            }
        }
        public Pabellon GetPabellon(int idPabellon) {
            try {
                return _context.Pabellones.FirstOrDefault(x => x.PabellonId == idPabellon);
            } catch (Exception ex) {
                return null;
            }
        }
        public dynamic CreatePabellon(Pabellon pabellon) {
            try {
                _context.Pabellones.Add(pabellon);
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

        public dynamic DeletePabellon(int idPabellon) {
            try {
                Pabellon pabellon = _context.Pabellones.FirstOrDefault(x => x.PabellonId == idPabellon);

                if (pabellon != null) {
                    _context.Pabellones.Remove(pabellon);
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

        public dynamic UpdatePabellon(Pabellon pabellon) {
            try {
                _context.Pabellones.Update(pabellon);
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
