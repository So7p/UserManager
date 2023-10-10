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
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            _logger.LogInformation("Requested all Users");

            var users = await _userService.GetAllAsync();

            return Ok(users);
        }

        [HttpGet("getById/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            _logger.LogInformation("Requested User by Id {id}", id);

            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                _logger.LogInformation("User was not found by Id {id}", id);

                return NotFound();
            }
                
            _logger.LogInformation("User successfully found by Id {id}: {@user}", id, user);

            return Ok(user);
        }

        [HttpGet("getByUserName/{userName}")]
        public async Task<IActionResult> GetByUserNameAsync([FromRoute] string userName)
        {
            _logger.LogInformation("Requested Users by Name {userName}", userName);

            var users = await _userService.GetByUserNameAsync(userName);

            _logger.LogInformation("Users found by Name {userName}: {@users}", userName, users);

            return Ok(users);
        }

        [HttpGet("getByAge/{age:int}")]
        public async Task<IActionResult> GetByAgeAsync([FromRoute] int age)
        {
            _logger.LogInformation("Requested Users by Age {age}", age);

            var users = await _userService.GetByAgeAsync(age);

            _logger.LogInformation("Users found by Age {age}: {@users}", age, users);

            return Ok(users);
        }

        [HttpGet("getByEmail/{email}")]
        public async Task<IActionResult> GetByEmailAsync([FromRoute] string email)
        {
            _logger.LogInformation("Requested User by Email {email}", email);

            var user = await _userService.GetByEmailAsync(email);

            if (user == null)
            {
                _logger.LogInformation("User was not found by Email {email}", email);

                return NotFound();
            }

            _logger.LogInformation("User successfully found by Email {email}: {@user}", email, user);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] UserForCreationDto userForCreationDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("User data was not valid: {@userForCreationDto}", userForCreationDto);

                return BadRequest();
            }  

            await _userService.CreateAsync(userForCreationDto);

            _logger.LogInformation("New User created: {@userForCreationDto}", userForCreationDto);

            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] UserForUpdateDto userForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("User data was not valid: {@userForUpdateDto}", userForUpdateDto);

                return BadRequest();
            }

            await _userService.UpdateAsync(userForUpdateDto);

            _logger.LogInformation("User data updated to: {@userForUpdateDto}", userForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _userService.DeleteAsync(id);

            _logger.LogInformation("User deleted by Id {id}", id);

            return NoContent();
        }
    }
}