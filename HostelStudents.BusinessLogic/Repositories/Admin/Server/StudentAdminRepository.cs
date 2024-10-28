using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin.Server;

public class StudentAdminRepository(ApplicationDbContext applicationDbContext) : IStudentAdminRepository
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<StudentAdminDto?> AddAsync(StudentAdminDto studentAdminDto)
    {
        if (string.IsNullOrWhiteSpace(studentAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => studentAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        if (string.IsNullOrWhiteSpace(studentAdminDto?.FirstName ?? string.Empty))
        {
            throw new Exception("First Name required.");
        }

        // AddRequiredPropertyCodePlaceholder

        var student = StudentAdminDto.ToStudent(user, studentAdminDto);

        student.NormalizedFirstName = studentAdminDto?.FirstName ?? string.Empty.ToUpperInvariant();
        student.NormalizedLastName = studentAdminDto?.LastName ?? string.Empty.ToUpperInvariant();
        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.Students.AddAsync(student);
        var databaseStudentAdminDto = StudentAdminDto.FromStudent(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseStudentAdminDto;
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseStudent = await _applicationDbContext.Students.FindAsync(id);

        if (databaseStudent == null)
        {
            return false;
        }

        databaseStudent.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseStudent);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<StudentAdminDto?> EditAsync(StudentAdminDto studentAdminDto)
    {
        if (string.IsNullOrWhiteSpace(studentAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => studentAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseStudent = await _applicationDbContext.Students.FindAsync(studentAdminDto.Id);

        if (databaseStudent == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        if (string.IsNullOrWhiteSpace(studentAdminDto?.FirstName ?? string.Empty))
        {
            throw new Exception("First Name required.");
        }

        // EditRequiredPropertyCodePlaceholder

        databaseStudent.ApplicationUserUpdatedBy = user;

        databaseStudent.FirstName = studentAdminDto?.FirstName ?? string.Empty;
        databaseStudent.NormalizedFirstName = studentAdminDto?.FirstName ?? string.Empty.ToUpperInvariant();
        databaseStudent.Hostel = studentAdminDto?.Hostel;
        databaseStudent.LastName = studentAdminDto?.LastName ?? string.Empty;
        // EditDatabasePropertyCodePlaceholder

        await _applicationDbContext.SaveChangesAsync();

        return studentAdminDto;
    }

    public async Task<List<StudentAdminDto>?> GetAllAsync(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        return await _applicationDbContext.Students

            // IncludeTableCodePlaceholder

            .Select(x => StudentAdminDto.FromStudent(x))
            .ToListAsync();
    }

    public async Task<StudentAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var result = await _applicationDbContext.Students.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return StudentAdminDto.FromStudent(result);
    }
}
