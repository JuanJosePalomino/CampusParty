using CampusParty.Models;

namespace CampusParty.Services {
    public interface IEquipoService {
        public IEnumerable<Equipo> GetEquipos();
        public Equipo GetEquipo(int idEquipo);
        public dynamic CreateEquipo(Equipo equipo);
        public dynamic UpdateEquipo(Equipo equipo);
        public dynamic DeleteEquipo(int idEquipo);
    }
}
