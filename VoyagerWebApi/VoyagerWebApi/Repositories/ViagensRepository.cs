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
            Viagens viagemBuscada = _context.Viagens.Include(v => v.Atividades).Include(v => v.Endereco).FirstOrDefault(v => v.ID == idViagem)!;

            if(viagemBuscada != null) 
            {
                return viagemBuscada;
            }

            return null;
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
    }
}
