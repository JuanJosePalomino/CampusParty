using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusParty.Models {
    public class Ciudad {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CiudadId { get; set; }
        public string Nombre { get; set; }
        public int NumeroHabitantes { get; set; }
        public int NumeroUniversidades { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }

    }
}
