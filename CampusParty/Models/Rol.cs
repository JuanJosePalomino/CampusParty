using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CampusParty.Models {
    public class Rol {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RolId { get; set; }
        public string Nombre { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
