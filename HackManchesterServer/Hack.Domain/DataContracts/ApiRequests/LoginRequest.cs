using System.ComponentModel.DataAnnotations;

namespace Hack.Domain.DataContracts.ApiRequests
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}