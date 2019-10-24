using Microsoft.AspNetCore.Identity;

namespace WebApi.Models
{
    public class UsuarioIdentity : IdentityUser
    {

        public string FullName { get; set; }

    }
}
