using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using AnimalShelter.Models;
using AnimalShelter.Helpers;

namespace AnimalShelter.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }

    public class UserService : IUserService
    {
        private AnimalShelterContext _users;

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, AnimalShelterContext db)
        {
            _appSettings = appSettings.Value;
            _users = db;
        }

        public User Authenticate(string username, string password)
        {
            Console.WriteLine($"\n\n\n\n\n" + $"here is username {username} and here is password {password}" + $"\n\n\n\n\n");
            var user = _users.Users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
              {
            Console.WriteLine($"\n\n\n\n\n" + "We are null" + $"\n\n\n\n\n");

                return null;
              }
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            List<User> u = new List<User> { };
            u = _users.Users.ToList();
            return u.Select(x =>
            {
                x.Password = null;
                return x;
            });
        }
    }
}