using AutoMapper;
using UserManager.Business.DTOs.RoleUser;
using UserManager.Business.Exceptions;
using UserManager.Business.Services.Contracts;
using UserManager.Data.Entities;
using UserManager.Data.Repositories.Contracts;

namespace UserManager.Business.Services.Implementation
{
    public class RoleUserService : IRoleUserService
    {
        private IMapper _mapper;
        private IRoleUserRepository _roleUserRepository;

        public RoleUserService(IMapper mapper, IRoleUserRepository roleUserRepository) 
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _roleUserRepository = roleUserRepository ?? throw new ArgumentNullException(nameof(_roleUserRepository));
        }

        public async Task<IEnumerable<RoleUserForViewDto>> GetAllAsync()
        {
            var roleUsers = await _roleUserRepository.GetAllAsync();

            var roleUsersViewModels = _mapper.Map<IEnumerable<RoleUserForViewDto>>(roleUsers);

            return roleUsersViewModels;
        }

        public async Task<RoleUserForViewDto?> GetByIdAsync(int id)
        {
            var roleUser = await _roleUserRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Record was not found.");

            var roleUserViewModel = _mapper.Map<RoleUserForViewDto>(roleUser);

            return roleUserViewModel;
        }

        public async Task<IEnumerable<RoleUserForViewDto>> GetByUserIdAsync(int userId)
        {
            var roleUsers = await _roleUserRepository.GetAllAsync();

            var roleUsersViewModels = _mapper.Map<IEnumerable<RoleUserForViewDto>>(roleUsers)
                .Where(r => r.UserId == userId);

            return roleUsersViewModels;
        }

        public async Task<IEnumerable<RoleUserForViewDto>> GetByUserNameAsync(string userName)
        {
            var roleUsers = await _roleUserRepository.GetAllAsync();

            var roleUsersViewModels = _mapper.Map<IEnumerable<RoleUserForViewDto>>(roleUsers)
                .Where(r => r.UserName == userName);

            return roleUsersViewModels;
        }

        public async Task<IEnumerable<RoleUserForViewDto>> GetByUserAgeAsync(int userAge)
        {
            var roleUsers = await _roleUserRepository.GetAllAsync();

            var roleUsersViewModels = _mapper.Map<IEnumerable<RoleUserForViewDto>>(roleUsers)
                .Where(r => r.UserAge == userAge);

            return roleUsersViewModels;
        }

        public async Task<IEnumerable<RoleUserForViewDto>> GetByUserEmailAsync(string userEmail)
        {
            var roleUsers = await _roleUserRepository.GetAllAsync();

            var roleUsersViewModels = _mapper.Map<IEnumerable<RoleUserForViewDto>>(roleUsers)
                .Where(r => r.UserEmail == userEmail);

            return roleUsersViewModels;
        }

        public async Task<IEnumerable<RoleUserForViewDto>> GetByUserRoleNameAsync(string userRoleName)
        {
            var roleUsers = await _roleUserRepository.GetAllAsync();

            var roleUsersViewModels = _mapper.Map<IEnumerable<RoleUserForViewDto>>(roleUsers)
                .Where(r => r.UserRoleName == userRoleName);

            return roleUsersViewModels;
        }

        public async Task CreateAsync(RoleUserForCreationDto roleUserForCreationDto)
        {
            if (roleUserForCreationDto == null)
                throw new ArgumentNullException(nameof(roleUserForCreationDto));

            var roleUser = _mapper.Map<RoleUser>(roleUserForCreationDto);

            await _roleUserRepository.CreateAsync(roleUser);
        }

        public async Task UpdateAsync(RoleUserForUpdateDto roleUserForUpdateDto)
        {
            if (roleUserForUpdateDto == null)
                throw new ArgumentNullException(nameof(roleUserForUpdateDto));

            var existingRoleUser = await _roleUserRepository.GetByIdAsync(roleUserForUpdateDto.Id)
                ?? throw new NotFoundException("Record was not found.");

            var roleUser = _mapper.Map<RoleUser>(roleUserForUpdateDto);

            await _roleUserRepository.UpdateAsync(roleUser);
        }

        public async Task DeleteAsync(int id)
        {
            var existingRoleUser = await _roleUserRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Record was not found.");

            await _roleUserRepository.DeleteAsync(id);
        }
    }
}