using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoyagerWebApi.Contexts;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;
using VoyagerWebApi.Repositories;
using VoyagerWebApi.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VoyagerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PostagensViagensController : ControllerBase
    {
        private readonly IPostagensViagens _postagensViagens;

        public PostagensViagensController()
        {
            _postagensViagens = new PostagensViagensRepository();
        }

        [HttpGet("{idPostagensViagens}")]
        public IActionResult BuscarPorId(Guid idPostagensViagens)
        {
            try
            {
                PostagensViagens postBuscada = _postagensViagens.BuscarPorId(idPostagensViagens);

                if (postBuscada == null)
                {
                    return NotFound("Viagem não encontrada");
                }

                return Ok(postBuscada);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost("Postar")]
        public IActionResult Postar (CadastrarPostagemViewModel post)
        {
            try
            {
                PostagensViagens postagensViagens = new PostagensViagens()
                {
                    Titulo = post.Titulo,
                    Descricao = post.Descricao,
                    IdViagem = post.IdViagem
                };

               _postagensViagens.Cadastrar(postagensViagens);

                return Ok("postagens FOI");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("Deletar")]
        public IActionResult Delete (Guid idPostagensViagens)
        {
            try
            {
                PostagensViagens postagensViagens = _postagensViagens.BuscarPorId(idPostagensViagens);

                if (postagensViagens == null)
                {
                    return NotFound("Postagem não encontrada");
                }
                return Ok(postagensViagens);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut]
        public IActionResult Atualizar (Guid idPostagens, CadastrarPostagemViewModel put)
        {
                try
                {
                _postagensViagens.Atualizar(idPostagens, put);

                    return NoContent();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
        }
    }
}
