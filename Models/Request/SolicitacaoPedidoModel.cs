
using System;

namespace WebApi.Models
{
    public class SolicitacaoPedidoModel
    {
        public string Id { get; set; }
        public bool Anunciante { get; set; } = false;
        public bool Solicitante { get; set; } = false;
    }
}
