using Aplication.Service;
using AutoMapper;
using Domain.Entity;
using Domain.EntityDto;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserServices : IUser
    {
        private readonly DataDBContext _context;
        private readonly IMapper _mapper;

        public UserServices(DataDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<GetUserDto> CreateUserAsync(CreateUserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<GetUserDto>(user);
            }
            catch (Exception ex)
            {
                // Xato haqida batafsil ma'lumotni yozish
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw; // Xatoni qayta otkazish
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            User? users = await _context.Users.FindAsync(id);
            if (users == null)
                return false;
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<List<GetUserDto>> GetAllUsersAsync()
        {
          var users = await  _context.Users.ToListAsync();
            return _mapper.Map<List<GetUserDto>>(users);
        }
     

        public async Task<GetUserDto> GetUserByIdAsync(int id)
        {
            var users = await  _context.Users.FindAsync(id);
            return users != null ? _mapper.Map<GetUserDto>(users) : null!;
        }

        public async Task<GetUserDto> UpdateUserAsync(UpdateUserDto user)
        {
            var users = _mapper.Map<User>(user);
                _context.Users.Update(users) ;
            return _mapper.Map<GetUserDto>(user);
            
        }
    }
}
