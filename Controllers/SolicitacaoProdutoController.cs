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
    public class SolicitacaoProdutoController : Controller
    {

        readonly dynamic retornoJSON = new Retorno();
        private readonly SolicitacaoProdutoRepositorio solicitacaoProdutorepositorio;
        private readonly ProdutoInteresseRepositorio interesserepositorio;
        private readonly SolicitacaoStatusRepositorio statusrepositorio;

        public SolicitacaoProdutoController(SolicitacaoProdutoRepositorio SolicitacaoProdutoRepositorio, ProdutoInteresseRepositorio interesseRepositorio, SolicitacaoStatusRepositorio statusRepositorio)
        {
            statusrepositorio = statusRepositorio;
            solicitacaoProdutorepositorio = SolicitacaoProdutoRepositorio;
            interesserepositorio = interesseRepositorio;
        }

        [HttpGet]
        [EnableQuery]
        public IEnumerable<SolicitacaoProduto> SolicitacaoProdutos()
        {
            return solicitacaoProdutorepositorio.ObterSolicitacaoProdutos();
        }

        [HttpPost]
        public JsonResult IniciarTransacao(SolicitacaoProdutoModel request)
        {
            #region IniciandoTransacao
            SolicitacaoProduto solicitacao = new SolicitacaoProduto();
            var produtoInteresse = interesserepositorio.InteressePorId(request.ProdutoInteresseId);
            produtoInteresse.IniciadoTransacao = true;
            interesserepositorio.AtualizarInteresse(produtoInteresse);
            var status = statusrepositorio.StatusPorId(request.StatusId);
            solicitacao.Produto = produtoInteresse.Produto;
            solicitacao.UsuarioAnunciante = produtoInteresse.UsuarioAnunciante;
            solicitacao.UsuarioSolicitante = produtoInteresse.UsuarioSolicitante;
            solicitacao.Quantidade = produtoInteresse.QuantidadeDesejada;
            solicitacao.Status = status;
            solicitacao.DataInicio = DateTime.Now;
            solicitacao.Lido = false;
            #endregion

            var result = solicitacaoProdutorepositorio.AdicionarSolicitacaoProduto(solicitacao);

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



        [Route("obterSolicitacoes")]
        public IList<SolicitacaoProduto> ObterSolicitacoesPorTipoUsuario(SolicitacaoPedidoModel request)
        {
            if (request.Anunciante)
                return solicitacaoProdutorepositorio.SolicitacoesPorAnunciante(request.Id);
            else
                return solicitacaoProdutorepositorio.SolicitacoesPorSolicitante(request.Id);
            
        }

    }
}
