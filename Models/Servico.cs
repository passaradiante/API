using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Servico
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public string UsuarioId { get; set; }
        public UsuarioIdentity Usuario { get; set; }
    }
}
