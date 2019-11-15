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
        private readonly ProdutoInteresseRepositorio interesserepositorio;
        readonly dynamic retornoJSON = new Retorno();

        public ProdutoController(
            ProdutoRepositorio produtoRepositorio,
            UserManager<UsuarioIdentity> userManager,
            CategoriaRepositorio categoriaRepositorio,
            ProdutoInteresseRepositorio interesseRepositorio
            )
        {
            repositorio = produtoRepositorio;
            _userManager = userManager;
            categrepositorio = categoriaRepositorio;
            interesserepositorio = interesseRepositorio;
        }

        [HttpGet]
        [EnableQuery()]
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

        [HttpPost]
        [Route("interesse")]
        public async Task<JsonResult> InteresseProduto(ProdutoInteresseModel request)
        {
            #region Registrando interesse
            ProdutoInteresse interesse = new ProdutoInteresse();
            var produto = repositorio.ProdutoPorId(request.ProdutoID);
            interesse.Produto = produto;
            interesse.UsuarioAnunciante = produto.Usuario;
            interesse.UsuarioSolicitante = await _userManager.FindByIdAsync(request.UsuarioSolicitanteID);
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

    }
}