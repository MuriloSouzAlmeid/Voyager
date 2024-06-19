using VoyagerWebApi.Domains;

namespace VoyagerWebApi.Interfaces
{
    public interface IAtividadesRepository
    {
        Atividade BuscarPorId(Guid idAtividade);
        List<Atividade> ListarPorViagem(Guid idViagem);
        void Cadastrar(Atividade novaAtividade);
        void Deletar(Guid idAtividade);
        void AtualizarStatusAtividade(Atividade atividade);
    }
}
