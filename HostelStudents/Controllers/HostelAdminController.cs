using HostelStudents.BusinessLogic.Entities.Dtos.Admin;
using HostelStudents.BusinessLogic.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;

namespace HostelStudents.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class HostelController(IHostelAdminRepository hostelAdminRepository) : ControllerBase
{
    private readonly IHostelAdminRepository _hostelAdminRepository = hostelAdminRepository;

    [HttpPost]
    public async Task<ActionResult<HostelAdminDto?>> Add(HostelAdminDto hostelAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(hostelAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseHostelAdminDto = await _hostelAdminRepository.AddAsync(hostelAdminDto);

        return Ok(databaseHostelAdminDto);
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

        var result = await _hostelAdminRepository.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<HostelAdminDto?>> Edit(HostelAdminDto hostelAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(hostelAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseHostel = await _hostelAdminRepository.EditAsync(hostelAdminDto);

        return Ok(databaseHostel);
    }

    [HttpGet]
    public async Task<ActionResult<HostelAdminDto>?> GetAll(string userName)
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

        var hostelAdminDtos = await _hostelAdminRepository.GetAllAsync(userIdentityName);

        return Ok(hostelAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HostelAdminDto?>> GetById(string userName, Guid id)
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

        var hostelAdminDto = await _hostelAdminRepository.GetByIdAsync(userIdentityName, id);

        return Ok(hostelAdminDto);
    }
}
