using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusParty.Models {
    public class UsuarioEvento {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioEventoId { get; set; }
        public string Carpa { get; set; }
        public string Vehiculo { get; set; }
        //public virtual Sitio Sitio { get; set; }
        public string Computador { get; set; }
        public int SitioId { get; set; }
        public int EventoId { get; set; }
        public int UsuarioId { get; set; }
        public bool Estadia { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Equipo> Equipos { get; set; }

    }
}
