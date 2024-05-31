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
                    Senha = Criptografia.GerarHash(dadosUsuario.Senha!),
                    Foto = "https://voyagerblobstorage.blob.core.windows.net/voyagercontainerblob/do-utilizador.png"
                };

                _usuariosRepository.Cadastrar(novoUsuario);

                return StatusCode(201, novoUsuario);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("DeletarConta/{idUsuario}")]
        public IActionResult Delete(Guid idUsuario)
        {
            try
            {
                Usuarios usuarioBuscado = _usuariosRepository.BuscarPorId(idUsuario);
                
                if (usuarioBuscado == null)
                {
                     return NotFound("Usuário não encontrado");
                }

                _usuariosRepository.Deletar(usuarioBuscado);

                return Ok("Usuário deletado com sucesso");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{idUsuario}")]
        public IActionResult Atualizar(Guid idUsuario, AtualizarUsuarioViewModel dadosAtualizados)
        {
            try
            {
                Usuarios usuarioBuscado = _usuariosRepository.BuscarPorId(idUsuario);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                _usuariosRepository.Atualizar(idUsuario, dadosAtualizados);

                return Ok("Usuário Atualizado");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("AtualizarFotoPerfil/{idUsuario}")]
        public IActionResult AtualizarFoto(Guid idUsuario, [FromForm] AtualizarFotoUsuarioViewModel arquivoForm)
        {
            try
            {
                // Lógica para atualizar foto

                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
