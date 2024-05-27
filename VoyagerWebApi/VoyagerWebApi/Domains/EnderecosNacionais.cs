using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("EnderecoNacional")]
    public class EnderecosNacionais
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(255)")]
        public string? Logradouro { get; set; }

        [Column(TypeName = "CHAR(2)")]
        [StringLength(2)]
        public string? Estado { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? Cidade { get; set; }
    }
}
