using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Requests

{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataRegistro { get; set; }
        public int Quantidade { get; set; }
        public float Valor { get; set; }
        public int CategoriaID { get; set; }
        public string UsuarioID { get; set; }
    }
}
