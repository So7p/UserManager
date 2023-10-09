using AutoMapper;
using UserManager.Business.DTOs.User;
using UserManager.Business.Exceptions;
using UserManager.Business.Services.Contracts;
using UserManager.Data.Entities;
using UserManager.Data.Repositories.Contracts;

namespace UserManager.Business.Services.Implementation
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository) 
        { 
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userRepository= userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<IEnumerable<UserForViewDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            var usersViewModels = _mapper.Map<IEnumerable<UserForViewDto>>(users);

            return usersViewModels;
        }

        public async Task<UserForViewDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("User was not found.");

            var userViewModel = _mapper.Map<UserForViewDto>(user);

            return userViewModel;
        }

        public async Task<IEnumerable<UserForViewDto>> GetByUserNameAsync(string userName)
        {
            var users = await _userRepository.GetByUserNameAsync(userName);

            var usersViewModels = _mapper.Map<IEnumerable<UserForViewDto>>(users);

            return usersViewModels;
        }

        public async Task<IEnumerable<UserForViewDto>> GetByAgeAsync(int age)
        {
            var users = await _userRepository.GetByAgeAsync(age);

            var usersViewModels = _mapper.Map<IEnumerable<UserForViewDto>>(users);

            return usersViewModels;
        }

        public async Task<UserForViewDto?> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email)
                ?? throw new NotFoundException("User was not found.");

            var userViewModel = _mapper.Map<UserForViewDto>(user);

            return userViewModel;
        }

        public async Task CreateAsync(UserForCreationDto userForCreationDto)
        {
            if (userForCreationDto == null)
                throw new ArgumentNullException(nameof(userForCreationDto));

            var user = _mapper.Map<User>(userForCreationDto);

            await _userRepository.CreateAsync(user);
        }

        public async Task UpdateAsync(UserForUpdateDto userForUpdateDto)
        {
            if (userForUpdateDto == null)
                throw new ArgumentNullException(nameof(userForUpdateDto));

            var existingUser = await _userRepository.GetByIdAsync(userForUpdateDto.Id)
                ?? throw new NotFoundException("User was not found.");

            var user = _mapper.Map<User>(userForUpdateDto);

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            var existingUser = await _userRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("User was not found.");

            await _userRepository.DeleteAsync(id);
        }
    }
}