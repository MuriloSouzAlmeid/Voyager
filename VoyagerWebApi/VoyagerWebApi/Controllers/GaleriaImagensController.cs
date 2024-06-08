using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;
using VoyagerWebApi.Repositories;
using VoyagerWebApi.Utils.BlobStorage;
using VoyagerWebApi.ViewModels;

namespace VoyagerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GaleriaImagensController : ControllerBase
    {
        private readonly IGaleriaImagensRepository _galeriaImagensRepository;

        public GaleriaImagensController()
        {
            _galeriaImagensRepository = new GaleriaImagensRepository();
        }

        [HttpGet("{idPostagem}")]
        public IActionResult BuscarPorPostagem(Guid idPostagem)
        {
            try
            {
                List<GaleriaImagens> listaDeFotos = _galeriaImagensRepository.ListarPorPostagem(idPostagem);

                return Ok(listaDeFotos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        [HttpGet]
        public IActionResult BuscarPorId(Guid ID)
        {
            try
            {
                GaleriaImagens fotoBuscada = _galeriaImagensRepository.BuscarFotoPorId(ID);

                return Ok(fotoBuscada);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAsync([FromForm] GaleriaImagensViewModel galeriaFotos)
        {
            try
            {
                GaleriaImagens galeria = new GaleriaImagens();

                galeria.IdPostagemViagem = galeriaFotos.IdPostagem;

                //Define o nome a partir do seu container no blob
                var containerName = "voyagercontainerblob";

                //Definindo a string de conexão
                var connectionString = "DefaultEndpointsProtocol=https;AccountName=voyagerblobstorage;AccountKey=KUCXzCqDYUNdIBbY9AM/qA1EA0Rw95VMMrT/+ceKyOwa/HbDiTmQlh6QN6beAAw0g/GQx/55x37k+AStjnaDRA==;EndpointSuffix=core.windows.net";

                galeria.Media = await AzureBlobStorageHelper.UploadImageBlobAsync(galeriaFotos.ArquivoMedia!, connectionString, containerName);

                _galeriaImagensRepository.CadastrarFoto(galeria);

                return Ok("cadastrado");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid ID)
        {
            try
            {
                GaleriaImagens fotoBuscada = _galeriaImagensRepository.BuscarFotoPorId(ID);

                if (fotoBuscada == null)
                {
                    return NotFound("Atividade não encontrada");
                }

                _galeriaImagensRepository.Deletar(ID);

                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
