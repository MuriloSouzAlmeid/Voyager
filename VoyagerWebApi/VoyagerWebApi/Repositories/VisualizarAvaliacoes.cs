using VoyagerWebApi.Contexts;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;

namespace VoyagerWebApi.Repositories
{
    public class VisualizarAvaliacoes : IVisualizarAvaliacoes
    {
        private readonly VoyagerContext ctx;

        public VisualizarAvaliacoes()
        {
            ctx = new VoyagerContext();
        }

        public void Atualizar(Guid IdUsuario, Guid IdPostagem)
        {
            Avaliacoes avaliacoes = ctx.Avaliacoes.FirstOrDefault(a => a.IdUsuario == IdUsuario && a.IdPostagemViagem == IdPostagem)!;

            if (avaliacoes != null)
            {
                if (avaliacoes.StatusAvaliacao == 1)
                {
                    avaliacoes.StatusAvaliacao = 0;
                }
                else
                {
                    avaliacoes.StatusAvaliacao = 1;
                }
                ctx.Avaliacoes.Update(avaliacoes);
                ctx.SaveChanges();
            }
        }

        public Avaliacoes BuscarPorPostUsuario(Guid IdUsuario, Guid IdPostagem)
        {
            Avaliacoes avaliacaoBuscada = ctx.Avaliacoes.FirstOrDefault(a => a.IdUsuario == IdUsuario && a.IdPostagemViagem == IdPostagem)!;

            return avaliacaoBuscada;
        }

        public void Cadastrar(Avaliacoes novaAvaliacao)
        {
            try
            {
                ctx.Avaliacoes.Add(novaAvaliacao);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
