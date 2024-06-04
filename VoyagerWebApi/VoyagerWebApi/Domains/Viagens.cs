using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyagerWebApi.Domains
{
    [Table("Viagem")]
    public class Viagens
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        public Guid IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuarios? Usuario { get; set; }

        public Guid IdTipoViagem { get; set; }

        [ForeignKey("IdTipoViagem")]
        public TiposViagem? TipoViagem { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime? DataInicial { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime? DataFinal { get; set; }

        public Guid IdStatusViagem { get; set; }

        [ForeignKey("IdStatusViagem")]
        public StatusViagens? StatusViagem { get; set; }

        public List<Atividade>? Atividades { get; set; }

        public EnderecosViagem? Endereco { get; set; }
    }
}
