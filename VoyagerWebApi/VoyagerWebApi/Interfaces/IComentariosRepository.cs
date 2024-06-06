using VoyagerWebApi.Domains;

namespace VoyagerWebApi.Interfaces
{
    public interface IComentariosRepository
    {
        void Cadastrar(Comentario novoComentario);
        void Deletar (Guid idComentario);
        Comentario BuscarPorId(Guid idComentario);
        List<Comentario> ListarPorPostagem(Guid idPostagem);
    }
}
