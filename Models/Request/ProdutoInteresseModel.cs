using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class ProdutoInteresseModel
    {
        public int ProdutoID { get; set; }
        public string UsuarioSolicitanteID { get; set; }
        public int Quantidade { get; set; }
    }
}
