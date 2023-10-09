using Microsoft.AspNetCore.Mvc;
using UserManager.Business.DTOs.User;
using UserManager.Business.Services.Contracts;

namespace UserManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService= userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();

            return Ok(users);
        }

        [HttpGet("getById/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("getByUserName/{userName}")]
        public async Task<IActionResult> GetByUserNameAsync([FromRoute] string userName)
        {
            var users = await _userService.GetByUserNameAsync(userName);

            return Ok(users);
        }

        [HttpGet("getByAge/{age:int}")]
        public async Task<IActionResult> GetByAgeAsync([FromRoute] int age)
        {
            var users = await _userService.GetByAgeAsync(age);

            return Ok(users);
        }

        [HttpGet("getByEmail/{email}")]
        public async Task<IActionResult> GetByEmailAsync([FromRoute] string email)
        {
            var user = await _userService.GetByEmailAsync(email);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] UserForCreationDto userForCreationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _userService.CreateAsync(userForCreationDto);

            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] UserForUpdateDto userForUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _userService.UpdateAsync(userForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _userService.DeleteAsync(id);

            return NoContent();
        }
    }
}