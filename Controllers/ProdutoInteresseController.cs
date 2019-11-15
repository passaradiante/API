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

        private readonly ProdutoInteresseRepositorio interesserepositorio;

        public ProdutoInteresseController(ProdutoInteresseRepositorio interesseRepositorio)
        {
            interesserepositorio = interesseRepositorio;
        }

        [Route("{id}")]
        public IList<ProdutoInteresse> GetInteresses(string id)
        {
            return interesserepositorio.InteressePorAnunciante(id);
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
