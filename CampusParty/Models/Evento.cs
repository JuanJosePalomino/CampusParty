using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusParty.Models {
    public class Evento {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int EventoId { get; set; }
        public bool Estado { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Temas { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public virtual ICollection<Pabellon> Pabellones { get; set; }

    }
}
