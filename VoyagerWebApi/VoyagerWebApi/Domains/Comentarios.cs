using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("Comentario")]
    public class Comentarios
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();
    }
}
