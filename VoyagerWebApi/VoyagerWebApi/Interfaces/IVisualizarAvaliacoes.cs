using VoyagerWebApi.Domains;

namespace VoyagerWebApi.Interfaces
{
    public interface IVisualizarAvaliacoes
    {
        Avaliacoes BuscarPorId(Guid IdUsuario, Guid IdPostagem);
        void Deletar(Avaliacoes avaliacao);
        void Cadastrar(Avaliacoes novaAvaliacao);
        Avaliacoes BuscarPorPostUsuario(Guid IdUsuario, Guid IdPostagem);
        bool VerificarCurtidoDescurtido(Guid idUsuario, Guid idPostagem);
        List<Avaliacoes> BuscarPorUsuario(Guid idUsuario);
    }
}
