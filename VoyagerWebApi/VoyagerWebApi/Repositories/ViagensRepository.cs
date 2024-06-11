using Microsoft.EntityFrameworkCore;
using VoyagerWebApi.Contexts;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;

namespace VoyagerWebApi.Repositories
{
    public class ViagensRepository : IViagensRepository
    {
        private readonly VoyagerContext _context;

        public ViagensRepository()
        {
            _context = new VoyagerContext();
        }

        public Viagens BuscarPorId(Guid idViagem)
        {
            Viagens viagemBuscada = _context.Viagens.Include(v => v.Atividades).Include(v => v.Endereco).Include(v => v.StatusViagem).FirstOrDefault(v => v.ID == idViagem)!;

            if(viagemBuscada != null) 
            {
                return viagemBuscada;
            }

            return null;
        }

        public Viagens BuscarViagemEmAndamento(Guid idUsuario)
        {
            StatusViagens statusEmAndamento = _context.StatusViagens.FirstOrDefault(s => s.Status == "EmAndamento")!;

            Viagens viagemBuscada = _context.Viagens
                .Include(v => v.Endereco)
                .FirstOrDefault(v => v.IdStatusViagem == statusEmAndamento.ID && v.IdUsuario == idUsuario)!;

            if (viagemBuscada == null)
            {
                return null;
            }

            return viagemBuscada;
        }

        public void CadastrarViagem(Viagens novaViagem)
        {
            _context.Viagens.Add(novaViagem);

            _context.SaveChanges();
        }

        public void DeletarViagem(Guid idViagem)
        {
            Viagens viagemBuscada = _context.Viagens.FirstOrDefault(v => v.ID == idViagem)!;

            if (viagemBuscada != null)
            {
                _context.Viagens.Remove(viagemBuscada);

                _context.SaveChanges();
            }
        }

        public List<Viagens> ListarViagensConcluidas(Guid idUsuario)
        {
            List<Viagens> listaDeViagens = _context.Viagens
                .Include(v => v.Atividades)
                .Include(v => v.Endereco)
                .Where(v => v.IdUsuario == idUsuario && v.StatusViagem.Status == "Concluida")
                .OrderBy(v => v.DataInicial)
                .ToList();

            return listaDeViagens;
        }

        public List<Viagens> ListarViagensPendentes(Guid idUsuario)
        {
            List<Viagens> listaDeViagens = _context
                .Viagens
                .Include(v => v.Atividades)
                .Include(v => v.Endereco)
                .Where(v => v.IdUsuario == idUsuario && v.StatusViagem.Status == "Pendente")
                .OrderBy(v => v.DataInicial)
                .ToList();

            return listaDeViagens;
        }
    }
}
