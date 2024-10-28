using System.Net.Http.Json;
using HostelStudents.BusinessLogic.Entities.Dtos.Admin;

namespace HostelStudents.BusinessLogic.Repositories.Admin.Client;

public class StudentClientAdminRepository(HttpClient httpClient) : IStudentAdminRepository
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<StudentAdminDto?> AddAsync(StudentAdminDto studentAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/studentAdmin", studentAdminDto);

        return await result.Content.ReadFromJsonAsync<StudentAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/studentAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<StudentAdminDto?> EditAsync(StudentAdminDto studentAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/studentAdmin/{studentAdminDto.Id}", studentAdminDto);

        return await result.Content.ReadFromJsonAsync<StudentAdminDto>();
    }

    public async Task<List<StudentAdminDto>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<StudentAdminDto>>($"/api/admin/studentAdmin?userName={userName}");

        return result;
    }

    public async Task<StudentAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<StudentAdminDto>($"/api/admin/studentAdmin/{id}?userName={userName}");

        return result;
    }
}
