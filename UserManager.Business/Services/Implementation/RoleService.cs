using AutoMapper;
using UserManager.Business.DTOs.Role;
using UserManager.Business.Exceptions;
using UserManager.Business.Services.Contracts;
using UserManager.Data.Entities;
using UserManager.Data.Repositories.Contracts;

namespace UserManager.Business.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private IMapper _mapper;
        private IRoleRepository _roleRepository;

        public RoleService(IMapper mapper, IRoleRepository roleRepository) 
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _roleRepository= roleRepository ?? throw new ArgumentNullException(nameof(_roleRepository));
        }

        public async Task<IEnumerable<RoleForViewDto>> GetAllAsync()
        {
            var roles = await _roleRepository.GetAllAsync();

            var rolesViewModels = _mapper.Map<IEnumerable<RoleForViewDto>>(roles);

            return rolesViewModels;
        }

        public async Task<RoleForViewDto?> GetByIdAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Role was not found.");

            var roleViewModel = _mapper.Map<RoleForViewDto>(role);

            return roleViewModel;
        }

        public async Task<RoleForViewDto?> GetByRoleNameAsync(string roleName)
        {
            var role = await _roleRepository.GetByRoleNameAsync(roleName)
                ?? throw new NotFoundException("Role was not found.");

            var roleViewModel = _mapper.Map<RoleForViewDto>(role);

            return roleViewModel;
        }

        public async Task CreateAsync(RoleForCreationDto roleForCreationDto)
        {
            if (roleForCreationDto == null)
                throw new ArgumentNullException(nameof(roleForCreationDto));

            var role = _mapper.Map<Role>(roleForCreationDto);

            await _roleRepository.CreateAsync(role);
        }

        public async Task UpdateAsync(RoleForUpdateDto roleForUpdateDto)
        {
            if (roleForUpdateDto == null)
                throw new ArgumentNullException(nameof(roleForUpdateDto));

            var existingRole = await _roleRepository.GetByIdAsync(roleForUpdateDto.Id)
                ?? throw new NotFoundException("Role was not found.");

            var role = _mapper.Map<Role>(roleForUpdateDto);

            await _roleRepository.UpdateAsync(role);
        }

        public async Task DeleteAsync(int id)
        {
            var existingRole = await _roleRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Role was not found.");

            await _roleRepository.DeleteAsync(id);
        }
    }
}