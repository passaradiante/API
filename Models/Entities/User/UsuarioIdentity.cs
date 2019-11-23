using Microsoft.AspNetCore.Identity;

namespace WebApi.Models
{
    public class UsuarioIdentity : IdentityUser
    {

        public string FullName { get; set; }

        //public string Address { get; set; }
        //public string AddressNumber { get; set; }
        //public string AddressComplement{ get; set; }

    }
}
