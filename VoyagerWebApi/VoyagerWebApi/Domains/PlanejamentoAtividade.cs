using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("PlanejamentoAtividade")]
    public class PlanejamentoAtividade
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        public Guid IdPlanejamento { get; set; }

        [ForeignKey("IdPlanejamento")]
        public Planejamentos? Planejamentos { get; set; }

        public Guid IdTipoAtividade { get; set; }

        [ForeignKey("IdTipoAtividade")]
        public TiposAtividade? TipoAtividade { get; set; }
    }
}
