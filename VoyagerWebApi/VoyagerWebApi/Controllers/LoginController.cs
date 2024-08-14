using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Azure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;
using VoyagerWebApi.Repositories;
using VoyagerWebApi.Utils;
using VoyagerWebApi.ViewModels;

namespace VoyagerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public LoginController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel dadosLogin)
        {
            try
            {
                Usuarios usuarioBuscado = _usuariosRepository.BuscarPorLogin(dadosLogin.Email!, dadosLogin.Senha!);

                if (usuarioBuscado == null)
                {
                    return NotFound("Email ou senha inválidos");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.ID.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("projeto-voyager-chave-autenticacao-webapi"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "webapi.projeto.voyager",
                    audience: "webapi.projeto.voyager",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(50),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
