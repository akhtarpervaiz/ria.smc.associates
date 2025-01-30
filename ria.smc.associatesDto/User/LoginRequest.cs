using System.ComponentModel.DataAnnotations;

namespace ria.smc.associates.UI.Models.Login
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
