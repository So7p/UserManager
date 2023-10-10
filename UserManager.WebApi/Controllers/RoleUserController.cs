using Microsoft.AspNetCore.Mvc;
using UserManager.Business.DTOs.RoleUser;
using UserManager.Business.DTOs.User;
using UserManager.Business.Services.Contracts;
using UserManager.Data.Entities;

namespace UserManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleUserController : Controller
    {
        private readonly IRoleUserService _roleUserService;
        private readonly ILogger<RoleUserController> _logger;

        public RoleUserController(IRoleUserService roleUserService, ILogger<RoleUserController> logger)
        {
            _roleUserService = roleUserService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            _logger.LogInformation("Requested all RoleUsers");

            var roleUsers = await _roleUserService.GetAllAsync();

            return Ok(roleUsers);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            _logger.LogInformation("Requested RoleUser by Id {id}", id);

            var roleUser = await _roleUserService.GetByIdAsync(id);

            if (roleUser == null)
            {
                _logger.LogInformation("RoleUser was not found by Id {id}", id);

                return NotFound();
            }

            _logger.LogInformation("RoleUser successfully found by Id {id}: {@roleUser}", id, roleUser);

            return Ok(roleUser);
        }

        [HttpGet("getByUserId/{userId:int}")]
        public async Task<IActionResult> GetByUserIdAsync([FromRoute] int userId)
        {
            _logger.LogInformation("Requested RoleUsers by User Id {userId}", userId);

            var roleUsers = await _roleUserService.GetByUserIdAsync(userId);

            _logger.LogInformation("RoleUsers found by User Id {userId}: {@roleUsers}", userId, roleUsers);

            return Ok(roleUsers);
        }

        [HttpGet("getByUserName/{userName}")]
        public async Task<IActionResult> GetByUserNameAsync([FromRoute] string userName)
        {
            _logger.LogInformation("Requested RoleUsers by Username {userName}", userName);

            var roleUsers = await _roleUserService.GetByUserNameAsync(userName);

            _logger.LogInformation("RoleUsers found by Username {userName}: {@roleUsers}", userName, roleUsers);

            return Ok(roleUsers);
        }

        [HttpGet("getByUserAge/{userAge:int}")]
        public async Task<IActionResult> GetByUserAgeAsync([FromRoute] int userAge)
        {
            _logger.LogInformation("Requested RoleUsers by User Age {userAge}", userAge);

            var roleUsers = await _roleUserService.GetByUserAgeAsync(userAge);

            _logger.LogInformation("RoleUsers found by User Age {userAge}: {@roleUsers}", userAge, roleUsers);

            return Ok(roleUsers);
        }

        [HttpGet("getByUserEmail/{userEmail}")]
        public async Task<IActionResult> GetByUserEmail([FromRoute] string userEmail)
        {
            _logger.LogInformation("Requested RoleUsers by User Email {userEmail}", userEmail);

            var roleUsers = await _roleUserService.GetByUserEmailAsync(userEmail);

            _logger.LogInformation("RoleUsers found by User Email {userEmail}: {@roleUsers}", userEmail, roleUsers);

            return Ok(roleUsers);
        }

        [HttpGet("getByUserRoleName/{userRoleName}")]
        public async Task<IActionResult> GetByUserRoleName([FromRoute] string userRoleName)
        {
            _logger.LogInformation("Requested RoleUsers by User Role {userRoleName}", userRoleName);

            var roleUsers = await _roleUserService.GetByUserRoleNameAsync(userRoleName);

            _logger.LogInformation("RoleUsers found by User Role {userRoleName}: {@roleUsers}", userRoleName, roleUsers);

            return Ok(roleUsers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] RoleUserForCreationDto roleUserForCreationDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("RoleUser data was not valid: {@roleUserForCreationDto}", roleUserForCreationDto);

                return BadRequest();
            }   

            await _roleUserService.CreateAsync(roleUserForCreationDto);

            _logger.LogInformation("New RoleUser created: {@roleUserForCreationDto}", roleUserForCreationDto);

            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] RoleUserForUpdateDto roleUserForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("User data was not valid: {@roleUserForUpdateDto}", roleUserForUpdateDto);

                return BadRequest();
            }

            await _roleUserService.UpdateAsync(roleUserForUpdateDto);

            _logger.LogInformation("User data updated to: {@roleUserForUpdateDto}", roleUserForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _roleUserService.DeleteAsync(id);

            _logger.LogInformation("RoleUser deleted by Id {id}", id);

            return NoContent();
        }
    }
}