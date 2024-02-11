using Application.Common.Interfaces.Persistence;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new() {
        
             new User { 
                 Id = Guid.NewGuid(),
                 EmailAddress = "string",
                 Name = "string",
                 Password = "string"
             }
        };

        public async Task AddAsync(User user)
        {
            await Task.Run(() => _users.Add(user));
        }

        public async Task<User?> GetUserByIdAsync(string email, string password)
        {
            return await Task.Run(() => 
            _users.Where(x => x.Password == password && x.EmailAddress == email)
            .FirstOrDefault());
        }
    }
}
