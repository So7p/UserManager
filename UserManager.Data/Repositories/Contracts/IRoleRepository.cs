﻿using UserManager.Data.Entities;

namespace UserManager.Data.Repositories.Contracts
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role?> GetByRoleNameAsync(string roleName);
    }
}