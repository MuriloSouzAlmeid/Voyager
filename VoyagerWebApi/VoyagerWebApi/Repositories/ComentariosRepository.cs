using VoyagerWebApi.Contexts;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;

namespace VoyagerWebApi.Repositories
{
    public class ComentariosRepository : IComentariosRepository
    {
        private readonly VoyagerContext _context;

        public ComentariosRepository()
        {
            _context = new VoyagerContext();
        }

        public Comentarios BuscarPorId(Guid idComentario)
        {
            Comentarios comentarioBuscado = _context.Comentarios.FirstOrDefault(c => c.ID == idComentario)!;

            if (comentarioBuscado == null)
            {
                return null;
            }

            return comentarioBuscado;
        }

        public void Cadastrar(Comentarios novoComentario)
        {
           
            _context.Comentarios.Add(novoComentario);

            _context.SaveChanges(); 
            
        }

        public void Deletar(Guid idComentario)
        {
            Comentarios comentarioBuscado = _context.Comentarios.FirstOrDefault(c => c.ID == idComentario)!;

            if (comentarioBuscado != null)
            {
                _context.Comentarios.Remove(comentarioBuscado);

                _context.SaveChanges();
            }
        }

        public List<Comentarios> ListarPorPostagem(Guid idPostagem)
        {
            List<Comentarios> listaDeComentarios = _context.Comentarios.Where(a => a.IdPostagemViagem == idPostagem).ToList();

            return listaDeComentarios;
        }
    }
}
