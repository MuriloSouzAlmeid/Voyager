using VoyagerWebApi.Interfaces;
using VoyagerWebApi.ViewModels;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Contexts;
using System.Linq;

namespace VoyagerWebApi.Repositories
{
    public class PostagensViagensRepository : IPostagensViagens
    {
        private readonly VoyagerContext ctx;

        public PostagensViagensRepository()
        {
            ctx = new VoyagerContext();
        }
        public void Atualizar(Guid IdPostagemViagem, CadastrarAtividadesViewModel dadosAtualizados)
        {
            //CadastrarAtividadesViewModel postagemBuscada = ctx.PostagensViagens.FirstOrDefault(dadosAtualizados)!;

            //if (postagemBuscada != null)
            //{
            //    postagemBuscada = dadosAtualizados;
            //}

            //ctx.SaveChanges();
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
