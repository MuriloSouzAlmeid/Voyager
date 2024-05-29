using VoyagerWebApi.Contexts;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Utils;
using VoyagerWebApi.Interfaces;
using VoyagerWebApi.ViewModels;

namespace VoyagerWebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly VoyagerContext _ctx;

        public UsuarioRepository()
        {
            _ctx = new VoyagerContext();
        }

        public Usuarios BuscarUsuarioPorId(Guid idUsuario)
        {
            Usuarios usuarioBuscado = _ctx.Usuarios.FirstOrDefault(u => u.ID == idUsuario)!;

            if(usuarioBuscado == null)
            {
                return null;
            }
            else
            {
                return usuarioBuscado;
            }
        }

        public void Cadastrar(CadastrarUsuarioViewModel novoUsuario)
        {
            Usuarios usuario = new Usuarios()
            {
                Nome = novoUsuario.Nome,
                Email = novoUsuario.Email,
                Senha = Criptografia.GerarHash(novoUsuario.Senha!)
            };

            _ctx.Usuarios.Add(usuario);

            _ctx.SaveChanges();
        }
    }
}
