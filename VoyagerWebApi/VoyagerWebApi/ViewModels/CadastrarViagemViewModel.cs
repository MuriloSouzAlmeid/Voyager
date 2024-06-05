namespace VoyagerWebApi.ViewModels
{
    public class CadastrarViagemViewModel
    {
       public DateTime? DataInicial { get; set;}
       public DateTime? DataFinal { get; set; }
       public string? PaisOrigem { get; set; }
       public string? CidadeOrigem { get; set; }
       public string? PaisDestino { get; set; }
       public string? CidadeDestino { get; set; }
       public Guid IdTipoViagem { get; set; }
       public Guid IdUsuario { get; set;}
    }
}
