using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusParty.Models {
    public class Software {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("Computador")]
        public int SoftwareId { get; set; }
        public string Nombre { get; set; }
        public double Valor { get; set; }
        public int Peso { get; set; }
        public virtual Computador Computador { get; set; }
    }
}
