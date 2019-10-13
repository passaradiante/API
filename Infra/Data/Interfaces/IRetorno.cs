using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.JsonRetorno
{
    public interface IRetorno
    {
        bool Validado { get; set; }
        string Mensagem { get; set; }
    }
}
