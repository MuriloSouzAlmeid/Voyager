using VoyagerWebApi.Contexts;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;

namespace VoyagerWebApi.Repositories
{
    public class EnderecosViagemRepository : IEnderecosViagemRepository
    {
        private readonly VoyagerContext _context;

        public EnderecosViagemRepository()
        {
            _context = new VoyagerContext();
        }

        public void Cadastrar(EnderecosViagem novoEndereco)
        {
            _context.EnderecosViagem.Add(novoEndereco);

            _context.SaveChanges();

        }

        public void DeletarPelaViagem(Guid idViagem)
        {
            EnderecosViagem enderecoBuscado = _context.EnderecosViagem.FirstOrDefault(e => e.IdViagem == idViagem)!;

            if(enderecoBuscado != null)
            {
                _context.EnderecosViagem.Remove(enderecoBuscado);

                _context.SaveChanges();
            }
        }
    }
}
