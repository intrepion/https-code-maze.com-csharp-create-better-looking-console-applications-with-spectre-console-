using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin.Server;

public class ApplicationRoleAdminRepository(ApplicationDbContext applicationDbContext) : IApplicationRoleAdminRepository
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<ApplicationRoleAdminDto?> AddAsync(ApplicationRoleAdminDto applicationRoleAdminDto)
    {
        if (string.IsNullOrWhiteSpace(applicationRoleAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var applicationUser = await _applicationDbContext.Users.FirstOrDefaultAsync(x => applicationRoleAdminDto.ApplicationUserName.ToUpperInvariant().Equals(x.NormalizedUserName));

        if (applicationUser == null)
        {
            throw new Exception("Authentication required.");
        }

        if (string.IsNullOrWhiteSpace(applicationRoleAdminDto.Name))
        {
            throw new Exception("Name required.");
        }

        var applicationRole = ApplicationRoleAdminDto.ToApplicationRole(applicationUser, applicationRoleAdminDto);

        var result = await _applicationDbContext.Roles.AddAsync(applicationRole);
        var databaseApplicationRoleAdminDto = ApplicationRoleAdminDto.FromApplicationRole(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseApplicationRoleAdminDto;
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpperInvariant().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseApplicationRole = await _applicationDbContext.Roles.FindAsync(id);

        if (databaseApplicationRole == null)
        {
            return false;
        }

        databaseApplicationRole.ApplicationUserUpdatedBy = user;

        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseApplicationRole);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<ApplicationRoleAdminDto?> EditAsync(ApplicationRoleAdminDto applicationRoleAdminDto)
    {
        if (string.IsNullOrWhiteSpace(applicationRoleAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var applicationUser = await _applicationDbContext.Users.FirstOrDefaultAsync(x => applicationRoleAdminDto.ApplicationUserName.ToUpperInvariant().Equals(x.NormalizedUserName));

        if (applicationUser == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseApplicationRole = await _applicationDbContext.Roles.FindAsync(applicationRoleAdminDto.Id);

        if (databaseApplicationRole == null)
        {
            throw new Exception("Application Role not found.");
        }

        if (string.IsNullOrWhiteSpace(applicationRoleAdminDto.Name))
        {
            throw new Exception("Name required.");
        }

        databaseApplicationRole.ApplicationUserUpdatedBy = applicationUser;
        databaseApplicationRole.Name = applicationRoleAdminDto.Name;
        databaseApplicationRole.NormalizedName = applicationRoleAdminDto.Name?.ToUpperInvariant();
        await _applicationDbContext.SaveChangesAsync();

        return applicationRoleAdminDto;
    }

    public async Task<List<ApplicationRoleAdminDto>?> GetAllAsync(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var applicationUser = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpperInvariant().Equals(x.NormalizedUserName));

        if (applicationUser == null)
        {
            throw new Exception("Authentication required.");
        }

        return await _applicationDbContext.Roles
            .Select(x => ApplicationRoleAdminDto.FromApplicationRole(x))
            .ToListAsync();
    }

    public async Task<ApplicationRoleAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var applicationUser = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpperInvariant().Equals(x.NormalizedUserName));

        if (applicationUser == null)
        {
            throw new Exception("Authentication required.");
        }

        var result = await _applicationDbContext.Roles.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return ApplicationRoleAdminDto.FromApplicationRole(result);
    }
}
