using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("Atividades")]
    public class Atividade
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(255)")]
        public string? TipoAtividade { get; set; }

        public Guid IdPlanejamento { get; set; }

        [ForeignKey("IdPlanejamento")]
        public Planejamentos? Planejamento { get; set;}
    }
}
