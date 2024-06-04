using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("Atividades")]
    public class Atividade
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

       [Column(TypeName ="DATETIME")]
        public DateTime? DataAtividade { get; set; }

        [Column(TypeName ="TEXT")]
        public string? DescricaoAtividade { get; set; }

        public Guid IdViagem { get; set; }

        [ForeignKey("IdPlanejamento")]
        public Viagens? Viagem { get; set;}
    }
}
