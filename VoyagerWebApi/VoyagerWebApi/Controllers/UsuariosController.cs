using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;
using VoyagerWebApi.Repositories;
using VoyagerWebApi.Utils;
using VoyagerWebApi.Utils.BlobStorage;
using VoyagerWebApi.Utils.Mail;
using VoyagerWebApi.ViewModels;

namespace VoyagerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;

        private readonly EmailSendingService emailSendingService;

        public UsuariosController(EmailSendingService service)
        {
            _usuariosRepository = new UsuariosRepository();
            emailSendingService = service;
        }

        [HttpGet("{idUsuario}")]
        public IActionResult BuscarPorId(Guid idUsuario) {
            try
            {
                Usuarios usuarioBuscado = _usuariosRepository.BuscarPorId(idUsuario);

                if(usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                return Ok(usuarioBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastrarUsuariosViewModel dadosUsuario)
        {
            try
            {
                Usuarios novoUsuario = new Usuarios()
                {
                    Nome = dadosUsuario.Nome,
                    Email = dadosUsuario.Email,
                    Senha = Criptografia.GerarHash(dadosUsuario.Senha!),
                    Foto = "https://voyagerblobstorage.blob.core.windows.net/voyagercontainerblob/do-utilizador.png"
                };

                _usuariosRepository.Cadastrar(novoUsuario);

                await emailSendingService.SendWelcomeEmail(dadosUsuario.Email!, novoUsuario.Nome!);

                return StatusCode(201, "Usuário cadastrado");

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("DeletarConta/{idUsuario}")]
        public IActionResult Delete(Guid idUsuario)
        {
            try
            {
                Usuarios usuarioBuscado = _usuariosRepository.BuscarPorId(idUsuario);
                
                if (usuarioBuscado == null)
                {
                     return NotFound("Usuário não encontrado");
                }

                _usuariosRepository.Deletar(usuarioBuscado);

                return Ok("Usuário deletado com sucesso");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{idUsuario}")]
        public IActionResult Atualizar(Guid idUsuario, AtualizarUsuarioViewModel dadosAtualizados)
        {
            try
            {
                Usuarios usuarioBuscado = _usuariosRepository.BuscarPorId(idUsuario);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                _usuariosRepository.Atualizar(idUsuario, dadosAtualizados);

                return Ok("Usuário Atualizado");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("AtualizarFotoPerfil/{idUsuario}")]
        public async Task<IActionResult> AtualizarFoto(Guid idUsuario, [FromForm] AtualizarFotoUsuarioViewModel arquivoForm)
        {
            try
            {
                Usuarios usuarioBuscado = _usuariosRepository.BuscarPorId(idUsuario);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                //Define o nome a partir do seu container no blob
                var containerName = "voyagercontainerblob";

                //Definindo a string de conexão
                var connectionString = "DefaultEndpointsProtocol=https;AccountName=voyagerblobstorage;AccountKey=KUCXzCqDYUNdIBbY9AM/qA1EA0Rw95VMMrT/+ceKyOwa/HbDiTmQlh6QN6beAAw0g/GQx/55x37k+AStjnaDRA==;EndpointSuffix=core.windows.net";

                //A chamada da função de upload de imagem
                string urlRetorno = await AzureBlobStorageHelper.UploadImageBlobAsync(arquivoForm.ArquivoFoto!, connectionString, containerName);

                _usuariosRepository.AtualizarFoto(idUsuario, urlRetorno);

                return Ok("Foto Atualizada");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("RedefinirSenha/{email}")]
        public IActionResult RedefinirSenha(string email, string novaSenha)
        {
            try
            {
                _usuariosRepository.RedefinirSenha(email, novaSenha);

                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
