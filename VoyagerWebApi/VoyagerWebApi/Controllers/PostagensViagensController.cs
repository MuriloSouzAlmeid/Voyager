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
    public class PostagensViagensController : ControllerBase
    {
        private readonly IPostagensViagensRepository _postagensViagens;

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
        public IActionResult Postar(CadastrarPostagemViewModel post)
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

                return Ok(postagensViagens.ID);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("Deletar")]
        public IActionResult Delete(Guid idPostagensViagens)
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
        public IActionResult Atualizar(Guid idPostagens, CadastrarPostagemViewModel put)
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

        [HttpGet("ListarPostagensCurtidas/{idUsuario}")]
        public IActionResult ListarCurtidas(Guid idUsuario)
        {
            try
            {
                List<PostagensViagens> listaDeCurtidas = _postagensViagens.ListarPorPostCurtidos(idUsuario);

                return Ok(listaDeCurtidas);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("ListarPostagensProprias/{idUsuario}")]
        public IActionResult ListarPostsProprios(Guid idUsuario)
        {
            try
            {
                List<PostagensViagens> listaDePostagens = _postagensViagens.ListarPorPostsPostados(idUsuario);

                return Ok(listaDePostagens);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet]
        public IActionResult ListarTodasPostagens()
        {
            try
            {
                List<PostagensViagens> listaDePostagens = _postagensViagens.ListarTodasPostagens();

                return Ok(listaDePostagens);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("BuscarPorViagem/{idViagem}")]
        public IActionResult BuscarPorViagem(Guid idViagem)
        {
            try
            {
                PostagensViagens postagemBuscada = _postagensViagens.BuscarPostagemPorViagem(idViagem);

                if(postagemBuscada == null)
                {
                    return NotFound();
                }

                return Ok(postagemBuscada);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
