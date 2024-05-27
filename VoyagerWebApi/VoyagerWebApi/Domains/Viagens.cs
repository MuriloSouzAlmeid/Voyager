using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("Viagem")]
    public class Viagens
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();
    }
}
