using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin;

public interface IApplicationUserAdminRepository
{
    Task<ApplicationUserAdminDto?> AddAsync(ApplicationUserAdminDto applicationUserAdminDto);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ApplicationUserAdminDto?> EditAsync(ApplicationUserAdminDto applicationUserAdminDto);
    Task<List<ApplicationUserAdminDto>?> GetAllAsync(string userName);
    Task<ApplicationUserAdminDto?> GetByIdAsync(string userName, Guid id);
}
