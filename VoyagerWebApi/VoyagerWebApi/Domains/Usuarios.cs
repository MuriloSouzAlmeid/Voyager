using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VoyagerWebApi.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuarios
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome obrigatório.")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Email obrigatório.")]
        public string? Email { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Senha obrigatória.")]
        public string? Senha { get; set; }

        [Column(TypeName = "TEXT")]
        public string? Foto { get; set; }

        [Column(TypeName = "TEXT")]
        public string? Bio { get; set; }

        public List<Comentario>? Comentarios { get; set; }

        public List<Avaliacoes>? Avaliacoes { get; set; }

        public EnderecosUsuario? EnderecoUsuario { get; set; }

        [Column(TypeName = "INT")]
        public int? CodRecupSenha { get; set; }
    }
}
