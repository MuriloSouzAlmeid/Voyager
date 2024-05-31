using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;
using VoyagerWebApi.Repositories;
using VoyagerWebApi.Utils;
using VoyagerWebApi.ViewModels;

namespace VoyagerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        [HttpGet]
        public IActionResult BuscarPorId(Guid idUsuario) {
            try
            {
                Usuarios usuarioBuscado = _usuariosRepository.BuscarPorId(idUsuario);

                if(usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                return Ok(usuarioBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarUsuariosViewModel dadosUsuario)
        {
            try
            {
                Usuarios novoUsuario = new Usuarios()
                {
                    Nome = dadosUsuario.Nome,
                    Email = dadosUsuario.Email,
                    Senha = Criptografia.GerarHash(dadosUsuario.Senha!)
                };

                _usuariosRepository.Cadastrar(novoUsuario);

                return StatusCode(201, novoUsuario);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
