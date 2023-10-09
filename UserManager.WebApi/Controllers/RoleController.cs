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

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var roles = await _roleService.GetAllAsync();

            return Ok(roles);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var role = await _roleService.GetByIdAsync(id);

            if (role == null)
                return NotFound();

            return Ok(role);
        }

        [HttpGet("{roleName}")]
        public async Task<IActionResult> GetByRoleNameAsync([FromRoute] string roleName)
        {
            var roles = await _roleService.GetByRoleNameAsync(roleName);

            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] RoleForCreationDto roleForCreationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _roleService.CreateAsync(roleForCreationDto);

            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] RoleForUpdateDto roleForUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _roleService.UpdateAsync(roleForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _roleService.DeleteAsync(id);

            return NoContent();
        }
    }
}