namespace WebApi.Models
{
    public class UsuarioIdentityModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int AddressNumber { get; set; }
    }
}
