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

        public void Atualizar(Guid IdAvaliacao)
        {
            Avaliacoes avaliacoes = ctx.Avaliacoes.FirstOrDefault(a => a.ID == IdAvaliacao);
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
