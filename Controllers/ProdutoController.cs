using System.Collections.Generic;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using WebApi.JsonRetorno;
using WebApi.Models;
using WebApi.Repositorio;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {

        private readonly ProdutoRepositorio repositorio;
        readonly dynamic retornoJSON = new Retorno();

        public ProdutoController(
            ProdutoRepositorio produtoRepositorio
            )
        {
            repositorio = produtoRepositorio;
        }

        [HttpGet]
        [EnableQuery()]
        public IEnumerable<Produto> Categorias() => repositorio.ObterProdutos();

        [HttpPost]
        [Route("cadastro")]
        public JsonResult Cadastrar(Produto produto)
        {
               var result = repositorio.AdicionarProduto(produto);
            if (result)
            {
                retornoJSON.Mensagem = "Produto cadastrado!";
                return Json(retornoJSON);
            }
            else
            {
                retornoJSON.Validado = false;
                retornoJSON.Mensagem = "Produto não cadastrado, verifique os dados do produto";
                return Json(retornoJSON);
            }            
        }

        [HttpPut("{id}")]
        public JsonResult Atualizar(int id, Produto produto)
        {

            produto.Id = id;

            if (repositorio.ExisteProduto(id))
            {
                repositorio.AtualizarProduto(produto);
                retornoJSON.Mensagem = "Produto atualizado!";
                return Json(retornoJSON);
            }
            else
            {
                retornoJSON.Validado = false;
                retornoJSON.Mensagem = "Produto não encontrado!";
                return Json(retornoJSON);
            }
        }

        [HttpDelete("{id}")]
        public JsonResult DeletarProduto(int id)
        {
            var produto = repositorio.ProdutoPorId(id);
            if (produto != null)
            {
                repositorio.DeletarProduto(produto);
                retornoJSON.Mensagem = "Produto deletado!";
                return Json(retornoJSON);
            }
            else
            {
                retornoJSON.Validado = false;
                retornoJSON.Mensagem = "Produto não encontrado!";
                return Json(retornoJSON);
            }
        }
    }
}