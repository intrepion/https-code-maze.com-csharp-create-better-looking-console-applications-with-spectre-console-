using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin;

public interface IApplicationRoleAdminRepository
{
    Task<ApplicationRoleAdminDto?> AddAsync(ApplicationRoleAdminDto applicationRoleAdminDto);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ApplicationRoleAdminDto?> EditAsync(ApplicationRoleAdminDto applicationRoleAdminDto);
    Task<List<ApplicationRoleAdminDto>?> GetAllAsync(string userName);
    Task<ApplicationRoleAdminDto?> GetByIdAsync(string userName, Guid id);
}
