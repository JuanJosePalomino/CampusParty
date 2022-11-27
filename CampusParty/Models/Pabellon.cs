using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CampusParty.Models {
    public class Pabellon {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PabellonId { get; set; }
        public string Tematica { get; set; }
        public string Area { get; set; }
        public string Ubicacion { get; set; }
        public int EventoId { get; set; }

        [ForeignKey("EventoId")]
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Evento Evento { get; set; }
        public virtual ICollection<Sitio> Sitios { get; set; }
    }
}
