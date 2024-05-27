using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("Planejamento")]
    public class Planejamentos
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();
    }
}
