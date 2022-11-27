using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusParty.Models {
    public class Equipo {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipoId { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public string Ciudad { get; set; }
        public ICollection<UsuarioEvento> UsuarioEventos { get; set; }

    }
}
