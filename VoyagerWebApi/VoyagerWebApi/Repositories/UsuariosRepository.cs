using Microsoft.EntityFrameworkCore;
using VoyagerWebApi.Contexts;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;
using VoyagerWebApi.Utils;
using VoyagerWebApi.ViewModels;

namespace VoyagerWebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly VoyagerContext _context;

        public UsuariosRepository() { 
            _context = new VoyagerContext();
        }

        public Usuarios Atualizar(Guid idUsuario, AtualizarUsuarioViewModel dadosAtualizados)
        {
            Usuarios usuarioBuscado = _context.Usuarios.FirstOrDefault(u => u.ID == idUsuario)!;

            if(usuarioBuscado != null)
            {
                if(dadosAtualizados.Bio != null)
                {
                    usuarioBuscado.Bio = dadosAtualizados.Bio;
                }

                if (dadosAtualizados.Cep != null)
                {    
                    EnderecosUsuario enderecoUsuario = new EnderecosUsuario()
                    {
                        Cep = dadosAtualizados.Cep,
                        Estado = dadosAtualizados.Estado,
                        Logradouro = dadosAtualizados.Logradouro,
                        Cidade = dadosAtualizados.Cidade,
                        IdUsuario = usuarioBuscado.ID
                    };

                    _context.EnderecosUsuarios.Add(enderecoUsuario);
               
                }

                _context.Update(usuarioBuscado);

                _context.SaveChanges();

                return usuarioBuscado;                
            }

            return null;
        }

        public Usuarios BuscarPorId(Guid idUsuario)
        {
            Usuarios usuarioBuscado = _context.Usuarios.Select(u => new Usuarios()
            {
                ID = u.ID,
                Nome = u.Nome,
                Email = u.Email,
                EnderecoUsuario = u.EnderecoUsuario
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

        public void Deletar(Usuarios usuario)
        {
            _context.Remove(usuario);

            _context.SaveChanges();
        }
    }
}
