using System;

namespace WebApi.Models
{
    public class SituacaoProduto : Base
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public UsuarioIdentity UsuarioAnunciante { get; set; }
        public UsuarioIdentity UsuarioSolicitante { get; set; }
        public SituacaoStatus Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public SituacaoMotivoCancelamento MotivoCancelamento { get; set; }
    }
}
