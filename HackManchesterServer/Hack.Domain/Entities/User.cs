using System;

namespace Hack.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Token { get; set; }

        public string GenerateToken()
        {
            Token = Guid.NewGuid().ToString("N");
            return Token;
        }

        public User()
        {
            // Parameterless constructor for EF
        }

        public User(string username, string password, string forename, string surname)
        {
            Username = username;
            Password = password;
            Forename = forename;
            Surname = surname;
        }
    }
}