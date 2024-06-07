using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VoyagerWebApi.ViewModels
{
    public class GaleriaImagensViewModel
    {
        public Guid IdPostagem { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IFormFile? ArquivoMedia { get; set; }
    }
}
