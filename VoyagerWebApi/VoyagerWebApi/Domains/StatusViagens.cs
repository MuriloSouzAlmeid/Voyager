using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("StatusViagem")]
    public class StatusViagens
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        public string? Status { get; set; }

        public List<Viagens>? Viagens { get; set; }
    }
}
