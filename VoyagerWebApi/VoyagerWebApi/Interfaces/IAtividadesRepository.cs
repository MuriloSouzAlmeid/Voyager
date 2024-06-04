using VoyagerWebApi.Domains;

namespace VoyagerWebApi.Interfaces
{
    public interface IAtividadesRepository
    {
        void Cadastrar(Atividade novaAtividade);
        void Deletar(Guid idAtividade);
    }
}
