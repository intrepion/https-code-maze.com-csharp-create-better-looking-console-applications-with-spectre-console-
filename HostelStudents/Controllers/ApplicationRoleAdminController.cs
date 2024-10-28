using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;
using ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class ApplicationRoleController(IApplicationRoleAdminRepository applicationRoleAdminRepository) : ControllerBase
{
    private readonly IApplicationRoleAdminRepository _applicationRoleAdminRepository = applicationRoleAdminRepository;

    [HttpPost]
    public async Task<ActionResult<ApplicationRoleAdminDto?>> Add(ApplicationRoleAdminDto applicationRoleAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(applicationRoleAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseApplicationRoleAdminDto = await _applicationRoleAdminRepository.AddAsync(applicationRoleAdminDto);

        return Ok(databaseApplicationRoleAdminDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool?>> Delete(string userName, Guid id)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(userName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var result = await _applicationRoleAdminRepository.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<ApplicationRoleAdminDto?>> Edit(ApplicationRoleAdminDto applicationRoleAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(applicationRoleAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseApplicationRole = await _applicationRoleAdminRepository.EditAsync(applicationRoleAdminDto);

        return Ok(databaseApplicationRole);
    }

    [HttpGet]
    public async Task<ActionResult<ApplicationRoleAdminDto>?> GetAll(string userName)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(userName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var applicationRoleAdminDtos = await _applicationRoleAdminRepository.GetAllAsync(userIdentityName);

        return Ok(applicationRoleAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationRoleAdminDto?>> GetById(string userName, Guid id)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(userName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var applicationRoleAdminDto = await _applicationRoleAdminRepository.GetByIdAsync(userIdentityName, id);

        return Ok(applicationRoleAdminDto);
    }
}
