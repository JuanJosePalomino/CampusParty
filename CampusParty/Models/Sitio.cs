using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusParty.Models {
    public class Sitio {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SitioId { get; set; }
        public string Codigo { get; set; }
        public bool Estado { get; set; }
        public int PabellonId { get; set; }

        [ForeignKey("PabellonId")]
        public virtual Pabellon Pabellon { get; set; }

    }
}
