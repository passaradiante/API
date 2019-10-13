using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.JsonRetorno
{
    public class Retorno : IRetorno
    {
        public bool Validado { get; set; } = true;

        public string Mensagem { get; set; } = "Ok";
    }
}
