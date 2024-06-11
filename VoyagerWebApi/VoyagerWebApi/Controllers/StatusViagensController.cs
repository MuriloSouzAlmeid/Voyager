using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Cryptography;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;
using VoyagerWebApi.Repositories;

namespace VoyagerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class StatusViagensController : ControllerBase
    {
        private readonly IStatusViagensRepository _statusRepository;
        private readonly IViagensRepository _viagensRepository;
        private readonly IUsuariosRepository _usuariosRepository;

        public StatusViagensController()
        {
            _statusRepository = new StatusViagensRepository();
            _viagensRepository = new ViagensRepository();
            _usuariosRepository = new UsuariosRepository();
        }

        [HttpPut("IniciarViagem")]
        public IActionResult IniciarViagem(Guid idViagem, Guid idUsuario)
        {
            try
            {
                Viagens viagemEmAndamento = _viagensRepository.BuscarViagemEmAndamento(idUsuario);
                Viagens viagemBuscada = _viagensRepository.BuscarPorId(idViagem);
                Usuarios usuarioBuscado = _usuariosRepository.BuscarPorId(idUsuario);

                if (viagemEmAndamento != null)
                {
                    return BadRequest("Não é possível iniciar 2 viagens ao mesmo tempo");
                }
                else
                {
                    if(usuarioBuscado != null && viagemBuscada != null)
                    {
                        _statusRepository.StatusIniciarViagem(idViagem);

                        return Ok("Viagem Iniciada");
                    }
                    else
                    {
                        return NotFound("Usuário ou Viagem não Encontrado");
                    }
                }
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("FinalizarViagem")]
        public IActionResult FinalizarViagem(Guid idViagem)
        {
            try
            {
                Viagens viagemBuscada = _viagensRepository.BuscarPorId(idViagem);

                if (viagemBuscada == null)
                {
                    return NotFound("Viagem não encontrada");
                }

                _statusRepository.StatusConcluirViagem(idViagem);

                return Ok("Viagem Finalizada");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
