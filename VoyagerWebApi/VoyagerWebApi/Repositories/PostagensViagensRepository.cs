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

        public List<PostagensViagens> ListarPorPostCurtidoEPostado(Guid idUsuario)
        {
            List<PostagensViagens> listaDePostagensTotal = ctx.PostagensViagens.Include(p => p.Avaliacoes).Include(p => p.Viagem).ToList();

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
    }
}
