using System.Net.Http.Json;
using System.Text.Json;
using Domain.Domain;
using Domain.Dto;
using HttpClients.Interfaces;

namespace HttpClients.Implementations;

public class ChildHttpClient : IChildService

{
    private readonly HttpClient client;

    public ChildHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<Child> AddAsync(ChildCreationDto dto)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/Child", dto);
        string response = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }

        Child savedChild = JsonSerializer.Deserialize<Child>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return savedChild;
    }

    public async Task<List<int>> GetAllIds()
    {
        HttpResponseMessage responseMessage = await client.GetAsync("/Child");
        string response = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }

        List<int> list = JsonSerializer.Deserialize<List<int>>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return list;
    }

    public async Task<List<Child>> GetAll()
    {
        HttpResponseMessage responseMessage = await client.GetAsync("/Child/All");
        string response = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }

        List<Child> list = JsonSerializer.Deserialize<List<Child>>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return list;
    }
}