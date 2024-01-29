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
        private static readonly List<User> _users = new();

        public void AddAsync(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByIdAsync(Guid id)
        {
           return _users.Where(x=>x.Id == id).FirstOrDefault();
        }
    }
}
