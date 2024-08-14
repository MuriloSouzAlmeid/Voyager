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
    public class AtividadesController : ControllerBase
    {
        private readonly IAtividadesRepository _atividadesRepository;
        private readonly IViagensRepository _viagensRepository;

        public AtividadesController()
        {
            _atividadesRepository = new AtividadesRepository();
            _viagensRepository = new ViagensRepository();
        }

        [HttpGet("{idViagem}")]
        public IActionResult BuscarPorViagem(Guid idViagem) 
        {
            try
            {
                List<Atividade> listaDeAtividades = _atividadesRepository.ListarPorViagem(idViagem);

                return Ok(listaDeAtividades);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost("{idViagem}")]
        public IActionResult Cadastrar(Guid idViagem, CadastrarAtividadesViewModel[] atividades)
        {
            try
            {
                Viagens viagem = _viagensRepository.BuscarPorId(idViagem);

                if(viagem == null)
                {
                    return NotFound("Viagem não encontrada");
                }

                foreach (CadastrarAtividadesViewModel atividade in atividades) 
                {
                    Atividade novaAtividade = new Atividade()
                    {
                        IdViagem = idViagem,
                        Concluida = false,
                        DataAtividade = atividade.Data,
                        DescricaoAtividade = atividade.Descricao
                    };

                    _atividadesRepository.Cadastrar(novaAtividade);
                }

                return Ok("Atividades Cadastradas");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{idAtividade}")]
        public IActionResult Delete(Guid idAtividade) 
        {
            try
            {
                Atividade atividadeBuscada = _atividadesRepository.BuscarPorId(idAtividade);

                if(atividadeBuscada == null)
                {
                    return NotFound("Atividade não encontrada");
                }

                return Ok(atividadeBuscada);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("AtualizarStatusAtividade")]
        public IActionResult AtualizarStatus(Guid idAtividade) 
        {
            try
            {
                Atividade atividadeBuscada = _atividadesRepository.BuscarPorId(idAtividade);

                if (atividadeBuscada == null)
                {
                    return NotFound("Atividade não encontrada");
                }

                _atividadesRepository.AtualizarStatusAtividade(atividadeBuscada);

                return Ok(atividadeBuscada);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
