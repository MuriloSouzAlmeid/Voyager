using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("TipoViagem")]
    public class TiposViagem
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(255)")]
        public string? TipoViagem { get; set; }

        public List<Viagens>? Viagens { get; set; }
    }
}
