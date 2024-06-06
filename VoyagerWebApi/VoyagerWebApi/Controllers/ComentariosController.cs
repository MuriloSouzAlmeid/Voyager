using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;
using VoyagerWebApi.Repositories;
using VoyagerWebApi.ViewModels;

namespace VoyagerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosController : ControllerBase
    {
        private readonly IComentariosRepository _comentariosRepository;
        
        public ComentariosController()
        {
            _comentariosRepository = new ComentariosRepository();
        }

        [HttpGet("{idPostagem}")]
        public IActionResult BuscarPorPostagem(Guid idPostagem)
        {
            try
            {
                List<Comentario> listaDeComentarios = _comentariosRepository.ListarPorPostagem(idPostagem);

                return Ok(listaDeComentarios);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        [HttpGet]
        public IActionResult BuscarPorId(Guid idComentario)
        {
            try
            {
                Comentario comentarioBuscado = _comentariosRepository.BuscarPorId(idComentario);

                return Ok(comentarioBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarComentarioViewModel novoComentario)
        {
            try
            {
                Comentario comentario = new Comentario()
                { 
                    IdPostagemViagem = novoComentario.IdPostagem,
                    IdUsuario = novoComentario.IdUsuario,
                    ComentarioTexto = novoComentario.ComentarioTexto
                };

                _comentariosRepository.Cadastrar(comentario);
                
                return Ok("cadastrado");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{idComentario}")]
        public IActionResult Delete(Guid idComentario)
        {
            try
            {
                Comentario comentarioBuscado = _comentariosRepository.BuscarPorId(idComentario);

                if (comentarioBuscado == null)
                {
                    return NotFound("Atividade não encontrada");
                }

                _comentariosRepository.Deletar(idComentario);

                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
