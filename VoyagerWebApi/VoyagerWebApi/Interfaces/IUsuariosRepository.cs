using VoyagerWebApi.Domains;
using VoyagerWebApi.ViewModels;

namespace VoyagerWebApi.Interfaces
{
    public interface IUsuariosRepository
    {
        void Cadastrar(Usuarios novoUsurio);
        Usuarios BuscarPorId(Guid idUsuario);
        Usuarios BuscarPorLogin(string email, string senha);
        Usuarios Atualizar(Guid idUsuario, AtualizarUsuarioViewModel dadosAtualizados);
        void Deletar(Usuarios usuario);
        void AtualizarFoto(Guid idUsuario, string urlFoto);
        void RedefinirSenha(string emailUsuario, string novaSenha);
    }
}
