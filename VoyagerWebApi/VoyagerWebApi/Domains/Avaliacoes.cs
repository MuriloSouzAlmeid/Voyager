using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("Avaliacao")]
    public class Avaliacoes
    {

        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();
    }
}
 