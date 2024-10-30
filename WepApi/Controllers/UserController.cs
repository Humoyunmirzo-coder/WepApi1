using Aplication.Service;
using Domain.EntityDto;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;

        public UserController(IUser userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            List<GetUserDto> users = await _userService.GetAllUsersAsync();
            return Ok(users);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<GetUserDto> CreateUser(CreateUserDto user)
        {
            var userdto = await _userService.CreateUserAsync(user);
            return userdto;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetUserDto>> UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            if (updateUserDto == null)
                return BadRequest("employee data must be provided.");

            var userUpdate = await _userService.UpdateUserAsync(updateUserDto);
            if (userUpdate == null)
            {
                return NotFound($"employee with ID {userUpdate.Id} not found.");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var isDeleted = await _userService.DeleteUserAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
