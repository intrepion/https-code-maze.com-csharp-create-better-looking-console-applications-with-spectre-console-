using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;
using ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class EntityNamePlaceholderController(IEntityNamePlaceholderAdminRepository EntityLowercaseNamePlaceholderAdminRepository) : ControllerBase
{
    private readonly IEntityNamePlaceholderAdminRepository _EntityLowercaseNamePlaceholderAdminRepository = EntityLowercaseNamePlaceholderAdminRepository;

    [HttpPost]
    public async Task<ActionResult<EntityNamePlaceholderAdminDto?>> Add(EntityNamePlaceholderAdminDto EntityLowercaseNamePlaceholderAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(EntityLowercaseNamePlaceholderAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseEntityNamePlaceholderAdminDto = await _EntityLowercaseNamePlaceholderAdminRepository.AddAsync(EntityLowercaseNamePlaceholderAdminDto);

        return Ok(databaseEntityNamePlaceholderAdminDto);
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

        var result = await _EntityLowercaseNamePlaceholderAdminRepository.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<EntityNamePlaceholderAdminDto?>> Edit(EntityNamePlaceholderAdminDto EntityLowercaseNamePlaceholderAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(EntityLowercaseNamePlaceholderAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseEntityNamePlaceholder = await _EntityLowercaseNamePlaceholderAdminRepository.EditAsync(EntityLowercaseNamePlaceholderAdminDto);

        return Ok(databaseEntityNamePlaceholder);
    }

    [HttpGet]
    public async Task<ActionResult<EntityNamePlaceholderAdminDto>?> GetAll(string userName)
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

        var EntityLowercaseNamePlaceholderAdminDtos = await _EntityLowercaseNamePlaceholderAdminRepository.GetAllAsync(userIdentityName);

        return Ok(EntityLowercaseNamePlaceholderAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EntityNamePlaceholderAdminDto?>> GetById(string userName, Guid id)
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

        var EntityLowercaseNamePlaceholderAdminDto = await _EntityLowercaseNamePlaceholderAdminRepository.GetByIdAsync(userIdentityName, id);

        return Ok(EntityLowercaseNamePlaceholderAdminDto);
    }
}
