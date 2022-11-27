using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusParty.Models {
    public class Computador {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComputadorId { get; set; }
        public string Serial { get; set; }
        public int RAM { get; set; }
        public int DiscoDuro { get; set; }
        public virtual Software Software { get; set; }
    }
}
