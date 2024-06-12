using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("Comentario")]
    public class Comentarios
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        public Guid IdPostagemViagem { get; set; }

        [ForeignKey("IdPostagemViagem")]
        public PostagensViagens? PostagemViagem { get; set; }

        public Guid IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuarios? Usuario { get; set; }

        [Column(TypeName ="TEXT")]
        public string? ComentarioTexto { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime? DataComentario { get; set; }
    }
}
