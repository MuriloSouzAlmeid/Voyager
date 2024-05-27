using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("PostagemViagem")]
    public class PostagensViagens
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();
    }
}
