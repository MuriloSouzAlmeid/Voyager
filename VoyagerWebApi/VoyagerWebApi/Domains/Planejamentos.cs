using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("Planejamento")]
    public class Planejamentos
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        public Guid IdViagem { get; set; }

        [ForeignKey("IdViagem")]
        public Viagens? Viagem { get; set; }

        [Column(TypeName = "TEXT")]
        public string? Descricao { get; set; }

        public List<Atividade>? Atividades { get; set;}
    }
}
