using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoyagerWebApi.Contexts;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;
using VoyagerWebApi.Repositories;

namespace VoyagerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class VisualizarAvaliacoesController : ControllerBase
    {
        private readonly IVisualizarAvaliacoes _VisualizarAvaliacoes;
        private readonly VoyagerContext _context;

        public VisualizarAvaliacoesController()
        {
            _VisualizarAvaliacoes = new VisualizarAvaliacoes();
            _context = new VoyagerContext();
        }

        [HttpPut("CurtirDescurtirPostagem")]
        public IActionResult Atualizar(Guid IdUsuario, Guid IdPostagem)
        {
            try
            {
                Avaliacoes avaliacaoBuscada = _VisualizarAvaliacoes.BuscarPorPostUsuario(IdUsuario, IdPostagem);

                if (avaliacaoBuscada == null)
                {
                    Usuarios usuario = _context.Usuarios.FirstOrDefault(u => u.ID == IdUsuario)!;

                    PostagensViagens postagem = _context.PostagensViagens.FirstOrDefault(p => p.ID == IdPostagem)!;

                    if (postagem == null || usuario == null)
                    {
                        return NotFound("Usuario ou postagem nao exites");
                    }
                    else
                    {
                        Avaliacoes novaAvaliacao = new Avaliacoes()
                        {
                            IdPostagemViagem = IdPostagem,
                            IdUsuario = IdUsuario,
                            StatusAvaliacao = 1
                        };

                        _VisualizarAvaliacoes.Cadastrar(novaAvaliacao);

                        return Ok("Avaliacao cadastrada");
                    }
                }
                else
                {
                    _VisualizarAvaliacoes.Atualizar(IdUsuario, IdPostagem);

                    return Ok("avaliacao atualizada");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
