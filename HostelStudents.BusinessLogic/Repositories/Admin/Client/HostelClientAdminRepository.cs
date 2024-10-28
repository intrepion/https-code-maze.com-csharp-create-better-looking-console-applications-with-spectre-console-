using System.Net.Http.Json;
using HostelStudents.BusinessLogic.Entities.Dtos.Admin;

namespace HostelStudents.BusinessLogic.Repositories.Admin.Client;

public class HostelClientAdminRepository(HttpClient httpClient) : IHostelAdminRepository
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<HostelAdminDto?> AddAsync(HostelAdminDto hostelAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/hostelAdmin", hostelAdminDto);

        return await result.Content.ReadFromJsonAsync<HostelAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/hostelAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<HostelAdminDto?> EditAsync(HostelAdminDto hostelAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/hostelAdmin/{hostelAdminDto.Id}", hostelAdminDto);

        return await result.Content.ReadFromJsonAsync<HostelAdminDto>();
    }

    public async Task<List<HostelAdminDto>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<HostelAdminDto>>($"/api/admin/hostelAdmin?userName={userName}");

        return result;
    }

    public async Task<HostelAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<HostelAdminDto>($"/api/admin/hostelAdmin/{id}?userName={userName}");

        return result;
    }
}
