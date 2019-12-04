using Microsoft.AspNetCore.Identity;

namespace WebApi.Models
{
    public class UsuarioIdentity : IdentityUser
    {

        public string FullName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int AddressNumber { get; set; }
    }
}
