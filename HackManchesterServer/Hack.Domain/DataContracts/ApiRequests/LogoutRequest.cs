using System.ComponentModel.DataAnnotations;

namespace Hack.Domain.DataContracts.ApiRequests
{
    public class LogoutRequest
    {
        [Required]
        public string Username { get; set; }
    }
}