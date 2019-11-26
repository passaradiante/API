using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.JsonRetorno;
using WebApi.Models;
using WebApi.Repositorio;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoInteresseController : Controller
    {

        readonly dynamic retornoJSON = new Retorno();
        private UserManager<UsuarioIdentity> _userManager;
        private readonly ProdutoInteresseRepositorio interesserepositorio;
        private readonly ProdutoRepositorio produtorepositorio;


        public ProdutoInteresseController(ProdutoInteresseRepositorio interesseRepositorio, ProdutoRepositorio produtoRepositorio, UserManager<UsuarioIdentity> userManager)
        {
            interesserepositorio = interesseRepositorio;
            _userManager = userManager;
            produtorepositorio = produtoRepositorio;
        }

        [HttpGet]
        public IEnumerable<ProdutoInteresse> ProdutoInteresses()
        {
            return interesserepositorio.ObterProdutoInteresses();
        }

        [Route("interessePorId/{id}")]
        public ProdutoInteresse ObterDadosInteressePorId(int id)
        {
            return interesserepositorio.InteressePorId(id);
        }

        [Route("{id}")]
        public IList<ProdutoInteresse> GetInteresses(string id)
        {
            return interesserepositorio.InteressePorAnunciante(id);
        }


        [HttpPost]
        [Route("interesse")]
        public async Task<JsonResult> InteresseProduto(ProdutoInteresseModel request)
        {

            #region Registrando interesse
            ProdutoInteresse interesse = new ProdutoInteresse();
            var produto = produtorepositorio.ProdutoPorId(request.ProdutoID);
            interesse.Produto = produto;
            interesse.UsuarioAnunciante = produto.Usuario;
            interesse.UsuarioSolicitante = await _userManager.FindByIdAsync(request.UsuarioSolicitanteID);
            if (request.Quantidade > 1) interesse.QuantidadeDesejada = request.Quantidade;
            #endregion

            var result = interesserepositorio.AdicionarRelacao(interesse);

            if (result)
            {
                retornoJSON.Mensagem = "Até aqui deu bom!";
                return Json(retornoJSON);
            }
            else
            {
                retornoJSON.Validado = false;
                retornoJSON.Mensagem = "Deu ruim!";
                return Json(retornoJSON);
            }

        }

        [Route("usuarioSolicitou/{idProduto}/{idUsuario}")]
        public JsonResult VerificarSeUsuarioSolicitou(int idProduto, string idUsuario)
        {
            var result = interesserepositorio.UsuarioJaSolicitou(idProduto, idUsuario);

            if (result)
            {
                retornoJSON.Mensagem = "Você já solicitou, aguarde!";
                return Json(retornoJSON);
            }
            else
            {
                retornoJSON.Validado = false;
                retornoJSON.Mensagem = "Pode solicitar, minha joia!";
                return Json(retornoJSON);
            }

        }

        [HttpPost]
        public JsonResult InteresseLido(ProdutoInteresseLido request)
        {
            var result = interesserepositorio.Lido(request.idNotificacao);
            if (result)
            {
                retornoJSON.Mensagem = "Interesse lido!";
                return Json(retornoJSON);
            }
            else
            {
                retornoJSON.Validado = false;
                retornoJSON.Mensagem = "Interesse não encontrado!";
                return Json(retornoJSON);
            }
        }
        
    }
}
