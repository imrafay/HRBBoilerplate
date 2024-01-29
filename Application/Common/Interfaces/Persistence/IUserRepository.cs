using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User GetUserByIdAsync(Guid id);

        void AddAsync(User user);
    }
}
