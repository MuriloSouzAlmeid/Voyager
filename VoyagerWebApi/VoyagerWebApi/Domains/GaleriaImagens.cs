using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("GaleriaImagem")]
    public class GaleriaImagens
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();
    }
}
