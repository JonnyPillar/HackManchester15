using System.Linq;
using System.Web.Http;
using Hack.Domain.DataContracts.ApiRequests;
using Hack.Domain.DataContracts.ApiResponses;
using Hack.Domain.Interfaces;
using Hack.EF;
using Hack.Server.Attributes;

namespace Hack.Server.ApiControllers
{
    public class AccountApiController : BaseApiController
    {
        public AccountApiController(HackDbContext hackDbContext, IApplicationContext applicationContext)
            : base(hackDbContext, applicationContext)
        {
        }

        [HttpPost]
        [Route("api/Accounts/Login")]
        public IHttpActionResult Login(LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = HackDbContext.Users.SingleOrDefault(x => x.Username.Equals(loginRequest.Username) && x.Password.Equals(loginRequest.Password));

            if (user == null)
            {
                return Unauthorized();
            }

            user.GenerateToken();
            HackDbContext.SaveChanges();

            return Ok(new LoginResponse(user.Token));
        }

        [CustomAuthorise]
        [HttpPost]
        [Route("api/Accounts/Logout")]
        public IHttpActionResult Logout(LogoutRequest logoutRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = HackDbContext.Users.SingleOrDefault(x => x.Username.Equals(logoutRequest.Username));

            if (user == null)
            {
                return InternalServerError();
            }

            user.Token = string.Empty;
            HackDbContext.SaveChanges();

            return Ok();
        }
    }
}