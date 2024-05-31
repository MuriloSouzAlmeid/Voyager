using VoyagerWebApi.Contexts;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;
using VoyagerWebApi.Utils;

namespace VoyagerWebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly VoyagerContext _context;

        public UsuariosRepository() { 
            _context = new VoyagerContext();
        }
        public Usuarios BuscarPorId(Guid idUsuario)
        {
            Usuarios usuarioBuscado = _context.Usuarios.Select(u => new Usuarios()
            {
                ID = u.ID,
                Nome = u.Nome,
                Email = u.Email
            }).FirstOrDefault(u => u.ID == idUsuario)!;

            if (usuarioBuscado == null)
            {
                return null;
            }

            return usuarioBuscado;
        }

        public Usuarios BuscarPorLogin(string email, string senha)
        {
            Usuarios usuarioBuscado = _context.Usuarios.FirstOrDefault(u => u.Email == email)!;

            if (usuarioBuscado != null) { 
  
                bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                if (confere)
                {
                    return usuarioBuscado;
                }
 
            }

            return null;
        }

        public void Cadastrar(Usuarios novoUsurio)
        {
            try
            {
                _context.Usuarios.Add(novoUsurio);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
