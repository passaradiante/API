using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class ProdutoInteresse
    {
        public int Id { get; set; }
        public UsuarioIdentity UsuarioSolicitante { get; set; }
        public UsuarioIdentity UsuarioAnunciante { get; set; }
        public Produto Produto { get; set; }
        public int QuantidadeDesejada { get; set; } = 1;
        public bool Lido { get; set; }

        
    }
}
