using VoyagerWebApi.Domains;

namespace VoyagerWebApi.Interfaces
{
    public interface IGaleriaImagensRepository
    {
        void CadastrarFoto(GaleriaImagens novaImagem);
        void Deletar(Guid ID);

        GaleriaImagens BuscarFotoPorId(Guid ID);

        List<GaleriaImagens> ListarPorPostagem(Guid idPostagem);
    }
}
