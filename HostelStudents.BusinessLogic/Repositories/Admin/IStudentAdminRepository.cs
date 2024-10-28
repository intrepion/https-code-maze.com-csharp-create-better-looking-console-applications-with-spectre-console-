using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin;

public interface IStudentAdminRepository
{
    Task<StudentAdminDto?> AddAsync(StudentAdminDto student);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<StudentAdminDto?> EditAsync(StudentAdminDto student);
    Task<List<StudentAdminDto>?> GetAllAsync(string userName);
    Task<StudentAdminDto?> GetByIdAsync(string userName, Guid id);
}
