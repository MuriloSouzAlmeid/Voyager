using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("EnderecoUsuario")]
    public class EnderecosUsuario
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(8)")]
        [StringLength(8, ErrorMessage = "O CEP deve possuir 8 caracteres")]
        public string? Cep { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string? Logradouro { get; set; }

        [Column(TypeName = "CHAR(2)")]
        public string? Estado { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string? Cidade { get; set; }

        public List<Usuarios>? Usuarios { get; set; }
    }
}
