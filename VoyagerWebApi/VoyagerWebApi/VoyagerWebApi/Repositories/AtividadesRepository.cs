using VoyagerWebApi.Contexts;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;

namespace VoyagerWebApi.Repositories
{
    public class AtividadesRepository : IAtividadesRepository
    {
        private readonly VoyagerContext _context;

        public AtividadesRepository()
        {
            _context = new VoyagerContext();
        }

        public void AtualizarStatusAtividade(Atividade atividade)
        {   
            if (atividade != null)
            {
                if(atividade.Concluida == false)
                {
                    atividade.Concluida = true;
                }
                else
                {
                    atividade.Concluida = false;
                }

                _context.Atividades.Update(atividade);

                _context.SaveChanges();
            }
        }

        public Atividade BuscarPorId(Guid idAtividade)
        {
            Atividade atividadeBuscada = _context.Atividades.FirstOrDefault(a => a.ID == idAtividade)!;

            if(atividadeBuscada == null)
            {
                return null;
            }

            return atividadeBuscada;
        }

        public void Cadastrar(Atividade novaAtividade)
        {
            _context.Atividades.Add(novaAtividade);
            
            _context.SaveChanges();
        }

        public void Deletar(Guid idAtividade)
        {
            Atividade atividadeBuscada = _context.Atividades.FirstOrDefault(a => a.ID == idAtividade)!;

            if(atividadeBuscada != null)
            {
                _context.Atividades.Remove(atividadeBuscada);

                _context.SaveChanges();
            }    
        }

        public List<Atividade> ListarPorViagem(Guid idViagem)
        {
            List<Atividade> listaDeAtividades = _context.Atividades.Where(a => a.IdViagem == idViagem).OrderBy(a => a.DataAtividade).ToList();

            return listaDeAtividades;
        }
    }
}
