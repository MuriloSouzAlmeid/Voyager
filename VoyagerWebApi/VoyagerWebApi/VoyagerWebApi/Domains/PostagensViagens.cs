using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("PostagemViagem")]
    public class PostagensViagens
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        public Guid IdViagem { get; set; }

        [ForeignKey("IdViagem")]
        public Viagens? Viagem { get; set; }

        [Column(TypeName = "TEXT")]
        public string? Descricao { get; set; }

        [Column(TypeName ="VARCHAR(255)")]
        public string? Titulo { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime? DataPostagem { get; set; }

        public List<Avaliacoes>? Avaliacoes { get; set; }

        public List<Comentarios>? Comentarios {  get; set; }
        
        public List<GaleriaImagens>? GaleriaImagens { get; set; }
    }
}
