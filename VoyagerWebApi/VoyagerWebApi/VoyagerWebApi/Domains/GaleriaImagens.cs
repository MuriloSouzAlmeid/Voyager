using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VoyagerWebApi.Domains
{
    [Table("GaleriaImagem")]
    public class GaleriaImagens
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        public Guid IdPostagemViagem { get; set; }

        [ForeignKey("IdPostagemViagem")]
        public PostagensViagens? PostagemViagenm { get; set; }

        [Column(TypeName = "TEXT")]
        public string? Media { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IFormFile? ArquivoMedia { get; set; }
    }
}
