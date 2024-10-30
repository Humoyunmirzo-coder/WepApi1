using Domain.Entity;
using Domain.EntityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service
{
    public  interface IUser
    {
        Task<GetUserDto> CreateUserAsync(CreateUserDto user);
        Task<GetUserDto> GetUserByIdAsync(int  id);
        Task<List<GetUserDto>> GetAllUsersAsync();
        Task<GetUserDto> UpdateUserAsync(UpdateUserDto user);
        Task<bool> DeleteUserAsync(int  id);
    }
}
