using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VoyagerWebApi.ViewModels
{
    public class GaleriaImagensViewModel
    {
        [NotMapped]
        [JsonIgnore]
        public IFormFile? ArquivoMedia { get; set; }
    }
}
