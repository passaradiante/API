using System;
using System.Collections.Generic;
using WebApi.Repositorio;

namespace WebApi.Models
{
    public class Categoria
    {

        public int Id { get; set; }
        public string Nome { get; set; }

        public static implicit operator Categoria(CategoriaRepositorio v)
        {
            throw new NotImplementedException();
        }
    }
}
