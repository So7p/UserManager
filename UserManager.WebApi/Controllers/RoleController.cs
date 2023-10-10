using Microsoft.AspNetCore.Mvc;
using UserManager.Business.DTOs.Role;
using UserManager.Business.Services.Contracts;

namespace UserManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<RoleController> _logger;

        public RoleController(IRoleService roleService, ILogger<RoleController> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            _logger.LogInformation("Requested all Roles");

            var roles = await _roleService.GetAllAsync();

            return Ok(roles);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            _logger.LogInformation("Requested Role by Id {id}", id);

            var role = await _roleService.GetByIdAsync(id);

            if (role == null)
            {
                _logger.LogInformation("Role was not found by Id {id}", id);

                return NotFound();
            }

            _logger.LogInformation("Role successfully found by Id {id}: {@role}", id, role);

            return Ok(role);
        }

        [HttpGet("{roleName}")]
        public async Task<IActionResult> GetByRoleNameAsync([FromRoute] string roleName)
        {
            _logger.LogInformation("Requested Role by Name {roleName}", roleName);

            var role = await _roleService.GetByRoleNameAsync(roleName);

            if (role == null)
            {
                _logger.LogInformation("Role was not found by Name {roleName}", roleName);

                return NotFound();
            }

            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] RoleForCreationDto roleForCreationDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Role data was not valid: {@roleForCreationDto}", roleForCreationDto);

                return BadRequest();
            }

            await _roleService.CreateAsync(roleForCreationDto);

            _logger.LogInformation("New Role created: {@roleForCreationDto}", roleForCreationDto);

            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] RoleForUpdateDto roleForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Role data was not valid: {@roleForUpdateDto}", roleForUpdateDto);

                return BadRequest();
            }

            await _roleService.UpdateAsync(roleForUpdateDto);

            _logger.LogInformation("Role data updated to: {@roleForUpdateDto}", roleForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _roleService.DeleteAsync(id);

            _logger.LogInformation("Role deleted by Id {id}", id);

            return NoContent();
        }
    }
}