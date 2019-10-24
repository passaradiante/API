using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public UsuarioController(UserManager<UsuarioIdentity> userManager, SignInManager<UsuarioIdentity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<Object> Cadastrar(UsuarioIdentityModel request)
        {
            var novoUsuario = new UsuarioIdentity()
            {
                UserName = request.UserName,
                Email = request.Email,
                FullName = request.FullName
            };

            var isUniqueEmail = (await _userManager.FindByEmailAsync(request.Email) == null);
            var isUniqueUserName = (await _userManager.FindByNameAsync(request.UserName) == null);

            if (!isUniqueEmail && !isUniqueUserName)
            {
                retornoJSON.Validado = true;
                retornoJSON.Mensagem = "Login ou Email já cadastrado!";
                return Json(retornoJSON);
            }

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

    }
}
