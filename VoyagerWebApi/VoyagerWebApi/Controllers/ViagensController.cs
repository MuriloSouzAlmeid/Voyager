using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoyagerWebApi.Contexts;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;
using VoyagerWebApi.Repositories;
using VoyagerWebApi.ViewModels;

namespace VoyagerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ViagensController : ControllerBase
    {
        private readonly IViagensRepository _viagensRepository;
        private readonly IEnderecosViagemRepository _enderecosRepository;
        private readonly VoyagerContext _context;

        public ViagensController()
        {
            _viagensRepository = new ViagensRepository();
            _enderecosRepository = new EnderecosViagemRepository();
            _context = new VoyagerContext();
        }

        [HttpGet("{idViagem}")]
        public IActionResult BuscarPorId(Guid idViagem)
        {
            try
            {
                Viagens viagemBuscada = _viagensRepository.BuscarPorId(idViagem);

                if (viagemBuscada == null)
                {
                    return NotFound("Viagem não encontrada");
                }

                return Ok(viagemBuscada);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarViagemViewModel viagemViewModel)
        {
            try
            {
                Guid idStatusPendente = _context.StatusViagens.FirstOrDefault(s => s.Status == "Pendente")!.ID;

                Viagens novaViagem = new Viagens()
                {
                    DataInicial = viagemViewModel.DataInicial,
                    DataFinal = viagemViewModel.DataFinal,
                    IdStatusViagem = idStatusPendente,
                    IdTipoViagem = viagemViewModel.IdTipoViagem,
                    IdUsuario = viagemViewModel.IdUsuario
                };

                _viagensRepository.CadastrarViagem(novaViagem);

                EnderecosViagem novoEndereco = new EnderecosViagem()
                {
                    CidadeOrigem = viagemViewModel.CidadeOrigem,
                    PaisOrigem = viagemViewModel.PaisOrigem,
                    CidadeDestino = viagemViewModel.CidadeDestino,
                    PaisDestino = viagemViewModel.PaisDestino,
                    IdViagem = novaViagem.ID
                };

                _enderecosRepository.Cadastrar(novoEndereco);

                return Ok("Viagem Cadastrada!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{idViagem}")]
        public IActionResult Delete(Guid idViagem)
        {
            try
            {
                Viagens viagemBuscada = _viagensRepository.BuscarPorId(idViagem);

                if (viagemBuscada == null)
                {
                    return NotFound("Viagem não encontrada");
                }

                _viagensRepository.DeletarViagem(viagemBuscada.ID);

                return Ok("Viagem Deletada");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
