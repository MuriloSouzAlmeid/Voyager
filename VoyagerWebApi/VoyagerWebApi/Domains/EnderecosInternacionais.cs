using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("EnderecoInternacional")]
    public class EnderecosInternacionais
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();
    }
}
