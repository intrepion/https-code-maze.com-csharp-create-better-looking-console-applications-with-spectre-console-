﻿using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin.Server;

public class HostelAdminRepository(ApplicationDbContext applicationDbContext) : IHostelAdminRepository
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<HostelAdminDto?> AddAsync(HostelAdminDto hostelAdminDto)
    {
        if (string.IsNullOrWhiteSpace(hostelAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => hostelAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        // AddRequiredPropertyCodePlaceholder

        var hostel = HostelAdminDto.ToHostel(user, hostelAdminDto);

        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.TableNamePlaceholder.AddAsync(hostel);
        var databaseHostelAdminDto = HostelAdminDto.FromHostel(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseHostelAdminDto;
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

        var databaseHostel = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (databaseHostel == null)
        {
            return false;
        }

        databaseHostel.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseHostel);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<HostelAdminDto?> EditAsync(HostelAdminDto hostelAdminDto)
    {
        if (string.IsNullOrWhiteSpace(hostelAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => hostelAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseHostel = await _applicationDbContext.TableNamePlaceholder.FindAsync(hostelAdminDto.Id);

        if (databaseHostel == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder

        databaseHostel.ApplicationUserUpdatedBy = user;

        // EditDatabasePropertyCodePlaceholder

        await _applicationDbContext.SaveChangesAsync();

        return hostelAdminDto;
    }

    public async Task<List<HostelAdminDto>?> GetAllAsync(string userName)
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

        return await _applicationDbContext.TableNamePlaceholder

            // IncludeTableCodePlaceholder

            .Select(x => HostelAdminDto.FromHostel(x))
            .ToListAsync();
    }

    public async Task<HostelAdminDto?> GetByIdAsync(string userName, Guid id)
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

        var result = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return HostelAdminDto.FromHostel(result);
    }
}
