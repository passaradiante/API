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
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepositorio repositorio;
        readonly dynamic retornoJSON = new Retorno();

        public UsuarioController(
            UsuarioRepositorio usuarioRepositorio
            )
        {
            repositorio = usuarioRepositorio;
        }

        //Obter Usuarios
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<UsuarioDominio> Lista() => repositorio.ObterUsuarios();

        //Buscar por ID
        [HttpGet("{id}")]
        public JsonResult Buscar(int id)
        {
            var usuario = repositorio.UsuarioPorId(id);
            if (usuario != null)
            {
                return Json(usuario);
            }
            else
            {
                retornoJSON.Validado = false;
                retornoJSON.Mensagem = "Usuario não encontrado";
                return Json(retornoJSON);
            }
        }

        //Adicionar um novo usuário
        [HttpPost]
        public JsonResult Cadastrar(UsuarioDominio usuario)
        {
            if (repositorio.ExisteEmailUsuario(usuario))
            {
                retornoJSON.Validado = false;
                retornoJSON.Mensagem = "E-mail já cadastrado";
                return Json(retornoJSON);
            }
            else
            {
                retornoJSON.Mensagem = "Usuario cadastrado com sucesso";
                repositorio.CadastrarUsuario(usuario);
                return Json(retornoJSON);
            }
        }

        //Atualizar dados de um usuário
        [HttpPut("{id}")]
        public JsonResult Atualizar(int id, UsuarioDominio usuario)
        {

            if (repositorio.ExisteUsuario(id))
            {
                retornoJSON.Mensagem = "Usuario atualizado com sucesso";
                repositorio.AtualizarUsuario(usuario);
                return Json(retornoJSON);
            }
            else
            {
                retornoJSON.Validado = false;
                retornoJSON.Mensagem = "Usuario não encontrado";
                return Json(retornoJSON);
            }
        }

        //Deletar um usuário
        [HttpDelete("{id}")]
        public JsonResult DeletarUsuario(int id)
        {
            var usuario = repositorio.UsuarioPorId(id);
            if (usuario != null)
            {
                retornoJSON.Mensagem = "Usuario deletado com sucesso";
                repositorio.DeletarUsuario(usuario);
                return Json(retornoJSON);
            }
            else
            {
                retornoJSON.Validado = false;
                retornoJSON.Mensagem = "Usuario não encontrado";
                return Json(retornoJSON);
            }
        }


    }
}
