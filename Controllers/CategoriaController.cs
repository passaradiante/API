using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.JsonRetorno;
using WebApi.Models;
using WebApi.Repositorio;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {

        private readonly CategoriaRepositorio repositorio;
        readonly dynamic retornoJSON = new Retorno();

        public CategoriaController(
            CategoriaRepositorio categoriaRepositorio
            )
        {
            repositorio = categoriaRepositorio;
        }

        [HttpGet]
        public IEnumerable<Categoria> Categorias() => repositorio.ObterCategorias();

        [HttpPost]
        public JsonResult Cadastrar(Categoria categoria)
        {
            if (repositorio.ExisteCategoria(categoria))
            {
                retornoJSON.Validado = false;
                retornoJSON.Mensagem = "Categoria já cadastrada!";
                return Json(retornoJSON);
            }
            else
            {
                repositorio.AdicionarCategoria(categoria);
                retornoJSON.Mensagem = "Categoria cadastrada!";
                return Json(retornoJSON);
            }
        }

        [HttpPut("{id}")]
        public JsonResult Atualizar(int id, Categoria categoria)
        {

            categoria.Id = id;

            if (repositorio.ExisteCategoria(id))
            {
                repositorio.AtualizarCategoria(categoria);
                retornoJSON.Mensagem = "Categoria atualizada!";
                return Json(retornoJSON);
            }
            else
            {
                retornoJSON.Validado = false;
                retornoJSON.Mensagem = "Categoria não encontrada!";
                return Json(retornoJSON);
            }
        }

        [HttpDelete("{id}")]
        public JsonResult DeletarCategoria(int id)
        {
            var categoria = repositorio.CategoriaoPorId(id);
            if (categoria != null)
            {
                repositorio.DeletarCategoria(categoria);
                retornoJSON.Mensagem = "Categoria deletada!";
                return Json(retornoJSON);
            }
            else
            {
                retornoJSON.Validado = false;
                retornoJSON.Mensagem = "Categoria não encontrada";
                return Json(retornoJSON);
            }
        }
    }
}