using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin;

public interface IHostelAdminRepository
{
    Task<HostelAdminDto?> AddAsync(HostelAdminDto hostel);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<HostelAdminDto?> EditAsync(HostelAdminDto hostel);
    Task<List<HostelAdminDto>?> GetAllAsync(string userName);
    Task<HostelAdminDto?> GetByIdAsync(string userName, Guid id);
}
