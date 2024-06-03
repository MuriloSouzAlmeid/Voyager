using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VoyagerWebApi.ViewModels
{
    public class AtualizarFotoUsuarioViewModel
    {
        [NotMapped]
        [JsonIgnore]
        public IFormFile? ArquivoFoto { get; set; }
    }
}
