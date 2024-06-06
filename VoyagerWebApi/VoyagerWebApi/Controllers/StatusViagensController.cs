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

        public StatusViagensController()
        {
            _statusRepository = new StatusViagensRepository();
            _viagensRepository = new ViagensRepository();
        }

        [HttpPut("IniciarViagem")]
        public IActionResult IniciarViagem(Guid idViagem, Guid idUsuario)
        {
            try
            {
                Viagens viagemBuscada = _viagensRepository.BuscarViagemEmAndamento(idUsuario);

                if (viagemBuscada != null)
                {
                    return BadRequest("Não é possível iniciar 2 viagens ao mesmo tempo");
                }
                else
                {
                    _statusRepository.StatusIniciarViagem(idViagem);

                    return Ok("Viagem Iniciada");
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
