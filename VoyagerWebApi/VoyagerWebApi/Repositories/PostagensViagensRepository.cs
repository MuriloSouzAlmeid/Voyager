using VoyagerWebApi.Contexts;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;
using VoyagerWebApi.ViewModels;

namespace VoyagerWebApi.Repositories
{
    public class PostagensViagensRepository : IPostagensViagensRepository
    {
        private readonly VoyagerContext ctx;

        public PostagensViagensRepository()
        {
            ctx = new VoyagerContext();
        }
        public void Atualizar(Guid IdPostagemViagem, CadastrarAtividadesViewModel dadosAtualizados)
        {
            throw new NotImplementedException();
        }

        public PostagensViagens BuscarPorId(Guid IdPostagemViagem)
        {
            PostagensViagens postagemBuscada = ctx.PostagensViagens.FirstOrDefault(x => x.ID == IdPostagemViagem);

            if (postagemBuscada == null)
            {
                return null;
            }
            return postagemBuscada;
        }

        public void Cadastrar(Domains.PostagensViagens novaPostagem)
        {
            try
            {
                ctx.PostagensViagens.Add(novaPostagem);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid IdPostagemViagem)
        {
            Domains.PostagensViagens postBuscado = ctx.PostagensViagens.FirstOrDefault(x => x.ID == IdPostagemViagem)!;

            if (postBuscado != null)
            {
                ctx.PostagensViagens.Remove(postBuscado);

                ctx.SaveChanges();
            }
        }
    }
}
