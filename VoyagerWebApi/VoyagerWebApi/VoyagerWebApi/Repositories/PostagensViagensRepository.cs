using Microsoft.EntityFrameworkCore;
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

        public void Atualizar(Guid IdPostagemViagem, CadastrarPostagemViewModel dadosAtualizados)
        {
            PostagensViagens postagemBuscada = ctx.PostagensViagens.FirstOrDefault(x => x.ID == IdPostagemViagem)!;

            if (postagemBuscada != null)
            {
                if (dadosAtualizados.Descricao != null)
                {
                    postagemBuscada.Descricao = dadosAtualizados.Descricao;

                }

                if (dadosAtualizados.Titulo != null)
                {
                    postagemBuscada.Titulo = dadosAtualizados.Titulo;
                }


                ctx.PostagensViagens.Update(postagemBuscada);
                ctx.SaveChanges();
            }

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

        public List<PostagensViagens> ListarPorPostCurtidos(Guid idUsuario)
        {
            List<PostagensViagens> listaDePostagensTotal = ctx.PostagensViagens
                .Include(p => p.Avaliacoes)
                .Include(p => p.Viagem)
                .Include(p => p.Viagem.Usuario)
                .Include(p => p.GaleriaImagens)
                .OrderByDescending(p => p.DataPostagem).ToList();

            List<PostagensViagens> listaDePostagensCurtidas = new List<PostagensViagens>();

            foreach (PostagensViagens postagem in listaDePostagensTotal)
            {
                if (postagem.Avaliacoes != null)
                {
                    foreach (Avaliacoes avaliacao in postagem.Avaliacoes)
                    {
                        if (avaliacao.StatusAvaliacao == 1 && avaliacao.IdUsuario == idUsuario)
                        {
                            listaDePostagensCurtidas.Add(postagem);
                        }
                    }
                }
            }

            return listaDePostagensCurtidas;
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

        public List<PostagensViagens> ListarPorPostsPostados(Guid idUsuario)
        {
            List<PostagensViagens> listaDePosts = ctx.PostagensViagens
                .Include(p => p.Viagem)
                .Include(p => p.Viagem)
                .Include(p => p.Viagem.Usuario)
                .Include(p => p.GaleriaImagens)
                .Where(p => p.Viagem.IdUsuario == idUsuario)
                .OrderByDescending(p => p.DataPostagem)
                .ToList();

            return listaDePosts;
        }

        public List<PostagensViagens> ListarTodasPostagens()
        {
            List<PostagensViagens> listaDePostagens = ctx.PostagensViagens.Include(p => p.Comentarios).Include(p => p.Viagem).Include(p => p.Viagem.Usuario).Include(p => p.GaleriaImagens).OrderByDescending(p => p.DataPostagem).ToList();

            return listaDePostagens;
        }

        public PostagensViagens BuscarPostagemPorViagem(Guid idViagem)
        {
            PostagensViagens postBuscado = ctx.PostagensViagens
                .Include(p => p.Viagem)
                .Include(p => p.Viagem.Usuario)
                .FirstOrDefault(p => p.IdViagem == idViagem)!;

            if (postBuscado == null)
            {
                return null;
            }

            return postBuscado;
        }
    }
}
