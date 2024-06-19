using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    public class EnderecosViagem
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        public Guid IdViagem { get; set; }

        [ForeignKey("IdViagem")]
        public Viagens? Viagem { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? PaisOrigem { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        public string? CidadeOrigem { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? PaisDestino { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        public string? CidadeDestino { get; set; }
    }
}
