using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoyagerWebApi.Contexts;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Utils.Mail;

namespace VoyagerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RecuperarSenhaController : ControllerBase
    {
        private readonly EmailSendingService emailSendingService;
        private readonly VoyagerContext _context;

        public RecuperarSenhaController(EmailSendingService service)
        {
            emailSendingService = service;
            _context = new VoyagerContext();
        }

        [HttpPost("EnviarEmail")]
        public async Task<IActionResult> SendMail(string email)
        {
            try
            {
                var usuarioBuscado = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuario não encontrado");
                }

                //Gerar um código com 4 algarismos

                Random random = new Random();
                int recoveryCode = random.Next(1000, 9999);

                usuarioBuscado.CodRecupSenha = recoveryCode;

                await _context.SaveChangesAsync();

                await emailSendingService.SendRecovery(usuarioBuscado.Email!, recoveryCode);

                return Ok("Email enviado com sucesso");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost("ValidarCodigoRecuperacao")]
        public async Task<IActionResult> ValidateRecoveryCode(string email, int codigo)
        {
            try
            {
                var usuarioBuscado = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email)!;

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                if (usuarioBuscado.CodRecupSenha != codigo)
                {
                    return BadRequest("Código informado inválido, tente novamente");
                }

                usuarioBuscado.CodRecupSenha = null;

                await _context.SaveChangesAsync();

                return Ok("Código de recupareção válido");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
