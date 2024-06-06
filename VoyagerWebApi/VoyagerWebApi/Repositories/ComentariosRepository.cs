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

        public Comentario BuscarPorId(Guid idComentario)
        {
            Comentario comentarioBuscado = _context.Comentarios.FirstOrDefault(c => c.ID == idComentario)!;

            if (comentarioBuscado == null)
            {
                return null;
            }

            return comentarioBuscado;
        }

        public void Cadastrar(Comentario novoComentario)
        {
           
            _context.Comentarios.Add(novoComentario);

            _context.SaveChanges(); 
            
        }

        public void Deletar(Guid idComentario)
        {
            Comentario comentarioBuscado = _context.Comentarios.FirstOrDefault(c => c.ID == idComentario)!;

            if (comentarioBuscado != null)
            {
                _context.Comentarios.Remove(comentarioBuscado);

                _context.SaveChanges();
            }
        }

        public List<Comentario> ListarPorPostagem(Guid idPostagem)
        {
            List<Comentario> listaDeComentarios = _context.Comentarios.Where(a => a.IdPostagemViagem == idPostagem).ToList();

            return listaDeComentarios;
        }
    }
}
