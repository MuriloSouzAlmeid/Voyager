using VoyagerWebApi.Domains;

namespace VoyagerWebApi.Interfaces
{
    public interface IComentariosRepository
    {
        void Cadastrar(Comentarios novoComentario);
        void Deletar(Guid idComentario);
        Comentarios BuscarPorId(Guid idComentario);
        List<Comentarios> ListarPorPostagem(Guid idPostagem);
    }
}
