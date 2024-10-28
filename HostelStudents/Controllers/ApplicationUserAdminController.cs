using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;
using ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class ApplicationUserController(IApplicationUserAdminRepository adminApplicationUserService) : ControllerBase
{
    private readonly IApplicationUserAdminRepository _adminApplicationUserService = adminApplicationUserService;

    [HttpPost]
    public async Task<ActionResult<ApplicationUserAdminDto?>> Add(ApplicationUserAdminDto applicationUserAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(applicationUserAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseApplicationUserAdminDto = await _adminApplicationUserService.AddAsync(applicationUserAdminDto);

        return Ok(databaseApplicationUserAdminDto);
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

        var result = await _adminApplicationUserService.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<ApplicationUserAdminDto?>> Edit(ApplicationUserAdminDto applicationUserAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(applicationUserAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseApplicationUserAdminDto = await _adminApplicationUserService.EditAsync(applicationUserAdminDto);

        return Ok(databaseApplicationUserAdminDto);
    }

    [HttpGet]
    public async Task<ActionResult<List<ApplicationUserAdminDto>?>> GetAll(string userName)
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

        var applicationUserAdminDtos = await _adminApplicationUserService.GetAllAsync(userIdentityName);

        return Ok(applicationUserAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationUserAdminDto?>> GetById(string userName, Guid id)
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

        var applicationUserAdminDto = await _adminApplicationUserService.GetByIdAsync(userIdentityName, id);

        return Ok(applicationUserAdminDto);
    }
}
