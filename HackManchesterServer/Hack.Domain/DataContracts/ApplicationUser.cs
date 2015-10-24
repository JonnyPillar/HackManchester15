namespace Hack.Domain.DataContracts
{
    public class ApplicationUser
    {
        public ApplicationUser(bool isAuth, long userId, string username)
        {
            IsAuthorised = isAuth;
            UserId = userId;
            Username = username;
        }

        public ApplicationUser(bool isAuth)
        {
            IsAuthorised = isAuth;
        }

        public bool IsAuthorised { get; private set; }
        public long UserId { get; private set; }
        public string Username { get; private set; }
    }
}