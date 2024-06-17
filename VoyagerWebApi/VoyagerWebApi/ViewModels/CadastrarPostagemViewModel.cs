namespace VoyagerWebApi.ViewModels
{
    public class CadastrarPostagemViewModel
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public Guid IdViagem { get; set; }
        public DateTime? DataPostagem { get; set; }
    }
}
