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
                List<Comentarios> listaDeComentarios = _comentariosRepository.ListarPorPostagem(idPostagem);

                return Ok(listaDeComentarios);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost("{idPostagem}")]
        public IActionResult Cadastrar(Guid idPostagem)
        {
            try
            {
                
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
                Comentarios comentarioBuscado = _comentariosRepository.BuscarPorId(idComentario);

                if (comentarioBuscado == null)
                {
                    return NotFound("Atividade não encontrada");
                }

                return Ok(comentarioBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
