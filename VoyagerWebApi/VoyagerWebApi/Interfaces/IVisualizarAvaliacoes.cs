using VoyagerWebApi.Domains;
using VoyagerWebApi.Repositories;

namespace VoyagerWebApi.Interfaces
{
    public interface IVisualizarAvaliacoes
    {
        void Atualizar(Guid IdAvaliacao);

        void Cadastrar(Avaliacoes novaAvaliacao);
    }
}
