using VoyagerWebApi.Domains;

namespace VoyagerWebApi.Interfaces
{
    public interface IUsuariosRepository
    {
        void Cadastrar(Usuarios novoUsurio);
        Usuarios BuscarPorId(Guid idUsuario);
        Usuarios BuscarPorLogin(string email, string senha);
    }
}
