using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Produto
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataRegistro { get; set; }
        public int Quantidade { get; set; }
        public float Valor { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public string UsuarioId { get; set; }
        public UsuarioIdentity Usuario { get; set; }
    }
}
