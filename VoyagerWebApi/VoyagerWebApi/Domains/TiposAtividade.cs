using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("TipoAtividade")]
    public class TiposAtividade
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(255)")]
        public string? TipoAtividade { get; set; }

        public List<Planejamentos>? Planejamentos { get; set; }
    }
}
