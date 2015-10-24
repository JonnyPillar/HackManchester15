using System;
using System.Collections.Generic;

namespace Hack.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            // Parameterless constructor for EF
        }

        public User(long id, string username, string password, string forename, string surname) : base(id)
        {
            Username = username;
            Password = password;
            Forename = forename;
            Surname = surname;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Token { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }

        public string GenerateToken()
        {
            Token = Guid.NewGuid().ToString("N");
            return Token;
        }
    }
}