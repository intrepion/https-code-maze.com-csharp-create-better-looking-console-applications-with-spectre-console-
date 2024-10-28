using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin.Client;

public class ApplicationRoleClientAdminRepository(HttpClient httpClient) : IApplicationRoleAdminRepository
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ApplicationRoleAdminDto?> AddAsync(ApplicationRoleAdminDto applicationRoleAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/applicationRoleAdmin", applicationRoleAdminDto);

        return await result.Content.ReadFromJsonAsync<ApplicationRoleAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/applicationRoleAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<ApplicationRoleAdminDto?> EditAsync(ApplicationRoleAdminDto applicationRoleAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/applicationRoleAdmin/{applicationRoleAdminDto.Id}", applicationRoleAdminDto);

        return await result.Content.ReadFromJsonAsync<ApplicationRoleAdminDto>();
    }

    public async Task<List<ApplicationRoleAdminDto>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<ApplicationRoleAdminDto>>($"/api/admin/applicationRoleAdmin?userName={userName}");

        return result;
    }

    public async Task<ApplicationRoleAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<ApplicationRoleAdminDto>($"/api/admin/applicationRoleAdmin/{id}?userName={userName}");

        return result;
    }
}
