namespace VoyagerWebApi.ViewModels
{
    public class CadastrarViagemViewModel
    {
       public DateTime? DataInicial { get; set;}
       public DateTime? DataFinal { get; set; }
       public string? Pais { get; set; }
       public string? Cidade { get; set; }
       public Guid IdTipoViagem { get; set; }
       public Guid IdUsuario { get; set;}
    }
}
