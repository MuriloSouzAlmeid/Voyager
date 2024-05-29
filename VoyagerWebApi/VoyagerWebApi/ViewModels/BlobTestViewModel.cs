using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VoyagerWebApi.ViewModels
{
    public class BlobTestViewModel
    {
        [NotMapped]
        [JsonIgnore]
        public IFormFile? File { get; set; }
    }
}
