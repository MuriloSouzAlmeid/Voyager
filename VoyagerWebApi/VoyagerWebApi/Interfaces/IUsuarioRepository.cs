using VoyagerWebApi.Domains;
using VoyagerWebApi.ViewModels;

namespace VoyagerWebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(CadastrarUsuarioViewModel novoUsuario);

        Usuarios BuscarUsuarioPorId(Guid idUsuario);
    }
}
