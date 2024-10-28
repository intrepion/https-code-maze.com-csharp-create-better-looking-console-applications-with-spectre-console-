﻿using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin.Client;

public class EntityNamePlaceholderClientAdminRepository(HttpClient httpClient) : IEntityNamePlaceholderAdminRepository
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<EntityNamePlaceholderAdminDto?> AddAsync(EntityNamePlaceholderAdminDto studentAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/studentAdmin", studentAdminDto);

        return await result.Content.ReadFromJsonAsync<EntityNamePlaceholderAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/studentAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<EntityNamePlaceholderAdminDto?> EditAsync(EntityNamePlaceholderAdminDto studentAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/studentAdmin/{studentAdminDto.Id}", studentAdminDto);

        return await result.Content.ReadFromJsonAsync<EntityNamePlaceholderAdminDto>();
    }

    public async Task<List<EntityNamePlaceholderAdminDto>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<EntityNamePlaceholderAdminDto>>($"/api/admin/studentAdmin?userName={userName}");

        return result;
    }

    public async Task<EntityNamePlaceholderAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<EntityNamePlaceholderAdminDto>($"/api/admin/studentAdmin/{id}?userName={userName}");

        return result;
    }
}
