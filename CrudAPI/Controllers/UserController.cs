using CrudAPI.Data.Services;
using CrudAPI.DTOs;
using CrudAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices )
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var user = await _userServices.GetAll();
            return user;
 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userServices.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDto userDto)
        {
            var user = await _userServices.Update(id, userDto);
            if (user == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(UserDto userDto)
        {
            var user = await _userServices.Add(userDto);

            return CreatedAtAction("GetUser", new { id = user.Id }, userDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userServices.Delete(id);

            return NoContent();
        }
    }

}

