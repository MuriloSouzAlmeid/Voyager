using VoyagerWebApi.Contexts;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;

namespace VoyagerWebApi.Repositories
{
    public class StatusViagensRepository : IStatusViagensRepository
    {
        private readonly VoyagerContext _context;

        public StatusViagensRepository()
        {
            _context = new VoyagerContext();
        }

        public StatusViagens BuscarStatus(string statusNome)
        {
            StatusViagens status = _context.StatusViagens.FirstOrDefault(s => s.Status==statusNome)!;

            if (status == null)
            {
                return null;
            }

            return status;
        }

        public void StatusConcluirViagem(Guid idViagem)
        {
            Viagens viagemBuscada = _context.Viagens.FirstOrDefault(v => v.ID == idViagem)!;

            StatusViagens statusAtualizado = BuscarStatus("Concluida");

            if (viagemBuscada != null && statusAtualizado != null)
            {
                viagemBuscada.IdStatusViagem = statusAtualizado.ID;

                _context.Viagens.Update(viagemBuscada);

                _context.SaveChanges();
            }

        }

        public void StatusIniciarViagem(Guid idViagem)
        {
            Viagens viagemBuscada = _context.Viagens.FirstOrDefault(v => v.ID == idViagem)!;

            StatusViagens statusAtualizado = BuscarStatus("EmAndamento");

            if (viagemBuscada != null && statusAtualizado != null)
            {
                viagemBuscada.IdStatusViagem = statusAtualizado.ID;

                _context.Viagens.Update(viagemBuscada);

                _context.SaveChanges();
            }
        }
    }
}
