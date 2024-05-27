using System.ComponentModel.DataAnnotations;

namespace VoyagerWebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo de email é obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo de senha é obrigatória")]
        public string? String { get; set; }
    }
}
