using CrudAPI.DTOs;
using CrudAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Data.Services
{
    public class UserServices : IUserServices
    {
        private readonly AppDbContext _context;
        public UserServices(AppDbContext context)
        {
            _context = context;
        }
        private static UserDto UserToDto(User user) => new UserDto
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Age = user.Age,
            PersonalNumber = user.PersonalNumber

        };

        public async Task<User> Add(UserDto userDto)
        {
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Age = userDto.Age,
                PersonalNumber = userDto.PersonalNumber
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await _context.Users.Select(x => UserToDto(x)).ToListAsync();
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return UserToDto(user);
        }

        public async Task<UserDto> Update(int id, UserDto userDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.Age = userDto.Age;
                user.PersonalNumber = userDto.PersonalNumber;

                await _context.SaveChangesAsync();
            }
            return userDto;
        }
    }
}
    

