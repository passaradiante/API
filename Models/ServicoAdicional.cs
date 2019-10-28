using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class ServicoAdicional
    {

        public int Id { get; set; }
        public string Nome { get; set; }

        public string UsuarioId { get; set; }
    }
}
