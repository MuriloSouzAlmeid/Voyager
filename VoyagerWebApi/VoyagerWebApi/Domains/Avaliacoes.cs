using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("Avaliacao")]
    public class Avaliacoes
    {

        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        public Guid IdPostagemViagem { get; set; }

        [ForeignKey("IdPostagemViagem")]
        public PostagensViagens? PostagemViagem { get; set; }

        public Guid IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuarios? Usuario { get; set; }

        [Column(TypeName = "INT")]
        public int? StatusAvaliacao { get; set; }


    }
}
 