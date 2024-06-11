using VoyagerWebApi.Domains;

namespace VoyagerWebApi.Interfaces
{
    public interface IVisualizarAvaliacoes
    {
        void Atualizar(Guid IdUsuario, Guid IdPostagem);

        void Cadastrar(Avaliacoes novaAvaliacao);

        Avaliacoes BuscarPorPostUsuario(Guid IdUsuario, Guid IdPostagem);

        bool VerificarCurtidoDescurtido(Guid idUsuario, Guid idPostagem);
    }
}
