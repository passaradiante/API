using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.JsonRetorno;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {

        readonly dynamic retornoJSON = new Retorno();

        private UserManager<UsuarioIdentity> _userManager;
        private SignInManager<UsuarioIdentity> _signInManager;
        private readonly ApplicationSettings _appSettings;

        public UsuarioController(UserManager<UsuarioIdentity> userManager, SignInManager<UsuarioIdentity> signInManager, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;

        }

        [HttpPost]
        [Route("cadastro")]
        public async Task<Object> Cadastrar(UsuarioIdentityModel request)
        {
            var novoUsuario = new UsuarioIdentity()
            {
                UserName = request.UserName,
                Email = request.Email,
                FullName = request.FullName
            };

            #region Validacao
            bool existeEmail = (await _userManager.FindByEmailAsync(request.Email) == null);
            bool existeEmailUserName = (await _userManager.FindByNameAsync(request.UserName) == null);

            if (!existeEmail && !existeEmailUserName)
            {
                retornoJSON.Validado = true;
                retornoJSON.Mensagem = "Login ou Email já cadastrado!";
                return Json(retornoJSON);
            }
            #endregion

            try
            {
                var result = await _userManager.CreateAsync(novoUsuario, request.Password);
                if (result.Succeeded)
                {
                    retornoJSON.Validado = true;
                    retornoJSON.Mensagem = "Usuario cadastrado";
                    return Json(retornoJSON);
                }
                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel request)
        {
            var usuario = await _userManager.FindByNameAsync(request.UserName);
            var checkPassword = await _userManager.CheckPasswordAsync(usuario, request.Password);

            if (usuario != null && checkPassword)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UsuarioID",usuario.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(
                       new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_KEY)),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
            {
                retornoJSON.Validado = false;
                retornoJSON.Mensagem = "Login/Senha inválidos!";
                return Json(retornoJSON);
            }

        
        }

        [HttpGet]
        [Authorize]
        public async Task<Object> GetDados()
        {
            string usuarioId = User.Claims.First(c => c.Type == "UsuarioID").Value;
            var user = await _userManager.FindByIdAsync(usuarioId);

            return new
            {
                user.FullName,
                user.Email,
                user.UserName,
                user.Id
            };

        }
}
}
