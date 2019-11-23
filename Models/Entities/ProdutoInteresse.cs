
namespace WebApi.Models
{
    public class ProdutoInteresse : Base
    {
        public UsuarioIdentity UsuarioSolicitante { get; set; }
        public UsuarioIdentity UsuarioAnunciante { get; set; }
        public Produto Produto { get; set; }
        public int QuantidadeDesejada { get; set; } = 1;
        public bool Lido { get; set; }
        public bool IniciadoTransacao { get; set; }    
    }
}
