namespace VoyagerWebApi.ViewModels
{
    public class CadastrarComentarioViewModel
    {
        public Guid IdPostagem { get; set; }
        public Guid IdUsuario { get; set; }
        public string? ComentarioTexto { get; set; }
    }
}
