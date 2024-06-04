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
    }
}
