using System;

namespace WebApi.Models
{
    public class SolicitacaoProduto : Base
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public UsuarioIdentity UsuarioAnunciante { get; set; }
        public UsuarioIdentity UsuarioSolicitante { get; set; }
        public SolicitacaoStatus Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public TiposMotivoCancelamento MotivoCancelamento { get; set; }
        public bool Lido { get; set; }

    }
}
