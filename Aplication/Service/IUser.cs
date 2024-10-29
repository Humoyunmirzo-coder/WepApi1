using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service
{
    public  interface IUser
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int  id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int  id);
    }
}
