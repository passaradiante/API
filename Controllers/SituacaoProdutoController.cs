using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi.JsonRetorno;
using WebApi.Models;
using WebApi.Repositorio;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SituacaoProdutoController : Controller
    {

        readonly dynamic retornoJSON = new Retorno();
        private readonly SituacaoProdutoRepositorio situacaoProdutorepositorio;
        private readonly ProdutoInteresseRepositorio interesserepositorio;
        private readonly SituacaoStatusRepositorio statusrepositorio;

        public SituacaoProdutoController(SituacaoProdutoRepositorio situacaoProdutoRepositorio, ProdutoInteresseRepositorio interesseRepositorio, SituacaoStatusRepositorio statusRepositorio)
        {
            statusrepositorio = statusRepositorio;
            situacaoProdutorepositorio = situacaoProdutoRepositorio;
            interesserepositorio = interesseRepositorio;
        }

        [HttpGet]
        [EnableQuery]
        public IEnumerable<SituacaoProduto> SituacaoProdutos()
        {
            return situacaoProdutorepositorio.ObterSituacaoProdutos();
        }

        [HttpPost]
        public JsonResult IniciarTransacao(SituacaoProdutoModel request)
        {
            #region IniciandoTransacao
            SituacaoProduto situacao = new SituacaoProduto();
            var produtoInteresse = interesserepositorio.InteressePorId(request.ProdutoInteresseId);
            produtoInteresse.IniciadoTransacao = true;
            interesserepositorio.AtualizarInteresse(produtoInteresse);
            var status = statusrepositorio.StatusPorId(request.StatusId);
            situacao.Produto = produtoInteresse.Produto;
            situacao.UsuarioAnunciante = produtoInteresse.UsuarioAnunciante;
            situacao.UsuarioSolicitante = produtoInteresse.UsuarioSolicitante;
            situacao.Quantidade = produtoInteresse.QuantidadeDesejada;
            situacao.Status = status;
            situacao.DataInicio = DateTime.Now;
            #endregion

            var result = situacaoProdutorepositorio.AdicionarSituacaoProduto(situacao);

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
