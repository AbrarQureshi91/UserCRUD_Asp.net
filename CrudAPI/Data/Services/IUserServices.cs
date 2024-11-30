using CrudAPI.DTOs;
using CrudAPI.Models;

namespace CrudAPI.Data.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(int id);
        Task<UserDto> Update(int id, UserDto userDto);
        Task<User> Add(UserDto userDto);
        Task Delete(int id);
    }
}