using Microsoft.AspNetCore.Mvc;
using UserManager.Business.DTOs.RoleUser;
using UserManager.Business.Services.Contracts;

namespace UserManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleUserController : Controller
    {
        private readonly IRoleUserService _roleUserService;

        public RoleUserController(IRoleUserService roleUserService)
        {
            _roleUserService = roleUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var roleUsers = await _roleUserService.GetAllAsync();

            return Ok(roleUsers);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var roleUser = await _roleUserService.GetByIdAsync(id);

            if (roleUser == null)
                return NotFound();

            return Ok(roleUser);
        }

        [HttpGet("getByUserId/{userId:int}")]
        public async Task<IActionResult> GetByUserIdAsync([FromRoute] int userId)
        {
            var roleUsers = await _roleUserService.GetByUserIdAsync(userId);

            return Ok(roleUsers);
        }

        [HttpGet("getByUserName/{userName}")]
        public async Task<IActionResult> GetByUserNameAsync([FromRoute] string userName)
        {
            var roleUsers = await _roleUserService.GetByUserNameAsync(userName);

            return Ok(roleUsers);
        }

        [HttpGet("getByUserAge/{userAge:int}")]
        public async Task<IActionResult> GetByUserAgeAsync([FromRoute] int userAge)
        {
            var roleUsers = await _roleUserService.GetByUserAgeAsync(userAge);

            return Ok(roleUsers);
        }

        [HttpGet("getByUserEmail/{userEmail}")]
        public async Task<IActionResult> GetByUserEmail([FromRoute] string userEmail)
        {
            var roleUsers = await _roleUserService.GetByUserEmailAsync(userEmail);

            return Ok(roleUsers);
        }

        [HttpGet("getByUserRoleName/{userRoleName}")]
        public async Task<IActionResult> GetByUserRoleName([FromRoute] string userRoleName)
        {
            var roleUsers = await _roleUserService.GetByUserRoleNameAsync(userRoleName);

            return Ok(roleUsers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] RoleUserForCreationDto roleUserForCreationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _roleUserService.CreateAsync(roleUserForCreationDto);

            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] RoleUserForUpdateDto roleUserForUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _roleUserService.UpdateAsync(roleUserForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _roleUserService.DeleteAsync(id);

            return NoContent();
        }
    }
}