using VoyagerWebApi.Domains;
using VoyagerWebApi.ViewModels;

namespace VoyagerWebApi.Interfaces
{
    public interface IPostagensViagens
    {
        void Cadastrar(PostagensViagens novaPostagem);

        void Deletar(Guid IdPostagemViagem);

        void Atualizar(Guid IdPostagemViagem, CadastrarAtividadesViewModel dadosAtualizados);

        PostagensViagens BuscarPorId (Guid IdPostagemViagem);
    }
}
