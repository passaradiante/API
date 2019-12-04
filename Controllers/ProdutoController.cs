using System.Collections.Generic;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using WebApi.JsonRetorno;
using WebApi.Models;
using WebApi.Requests;
using WebApi.Repositorio;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {

        private readonly ProdutoRepositorio repositorio;
        private readonly CategoriaRepositorio categrepositorio;
        private UserManager<UsuarioIdentity> _userManager;
        readonly dynamic retornoJSON = new Retorno();

        public ProdutoController(
            ProdutoRepositorio produtoRepositorio,
            UserManager<UsuarioIdentity> userManager,
            CategoriaRepositorio categoriaRepositorio
            )
        {
            repositorio = produtoRepositorio;
            _userManager = userManager;
            categrepositorio = categoriaRepositorio;
        }

        [HttpGet]
        [EnableQuery]
        public IEnumerable<Produto> Produtos() => repositorio.ObterProdutos();

        [HttpPost]
        [Route("cadastro")]
        public async Task<JsonResult> Cadastrar(ProdutoModel request)
        {

            #region Novo Produto
            Produto produto = new Produto();
            produto.Id = request.Id;
            produto.Nome = request.Nome;
            produto.Descricao = request.Descricao;
            produto.DataRegistro = request.DataRegistro;
            produto.Quantidade = request.Quantidade;
            produto.Valor = request.Valor;
            produto.Usuario = await _userManager.FindByIdAsync(request.UsuarioID);
            produto.Categoria = categrepositorio.CategoriaoPorId(request.CategoriaID);
            #endregion

            var result = repositorio.AdicionarProduto(produto);
            if (result)
            {
                retornoJSON.Mensagem = "Produto cadastrado!";
                return Json(retornoJSON);
            }
            else
            {
                retornoJSON.Validado = false;
                retornoJSON.Mensagem = "Produto não cadastrado, verifique os dados do produto.";
                return Json(retornoJSON);
            }            
        }

        [HttpPut("{id}")]
        public async Task<JsonResult> Atualizar(int id, ProdutoModel request)
        {

            request.Id = id;

            #region Produto editado
            Produto produto = new Produto();
            produto.Id = request.Id;
            produto.Nome = request.Nome;
            produto.Descricao = request.Descricao;
            produto.DataRegistro = request.DataRegistro;
            produto.Quantidade = request.Quantidade;
            produto.Valor = request.Valor;
            produto.Usuario = await _userManager.FindByIdAsync(request.UsuarioID);
            produto.Categoria = categrepositorio.CategoriaoPorId(request.CategoriaID);
            #endregion

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
                retornoJSON.Mensagem = "Anúncio deletado!";
                return Json(retornoJSON);
            }
            else
            {
                retornoJSON.Validado = false;
                retornoJSON.Mensagem = "Produto não encontrado!";
                return Json(retornoJSON);
            }
        }

        [HttpGet]
        [Route("produtoDoAnunciante/{idProduto}/{idUsuario}")]
        public JsonResult EhProdutoDoAnuncinte(int idProduto, string idUsuario)
        {
            var result = repositorio.VerificarSeEhProdutoDoAnunciante(idUsuario, idProduto);
            if (result)
            {
                return Json(retornoJSON);
            }
            else
            {
                retornoJSON.Validado = false;
                return Json(retornoJSON);
            }
        }
       
    }
}