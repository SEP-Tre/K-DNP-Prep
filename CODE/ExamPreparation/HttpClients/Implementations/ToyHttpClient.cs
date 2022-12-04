using System.Net.Http.Json;
using System.Text.Json;
using Domain.Domain;
using HttpClients.Interfaces;

namespace HttpClients.Implementations;

public class ToyHttpClient : IToyService
{
    
    private readonly HttpClient client;

    public ToyHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<Toy> AssignToy(int id, Toy toy)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync($"/Toy/owner/{id}", toy);
        string response = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }

        Toy savedToy = JsonSerializer.Deserialize<Toy>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return savedToy;
    }

    public async Task<List<Toy>> GetAll()
    {
        HttpResponseMessage responseMessage = await client.GetAsync("/Toy/All");
        string response = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }

        List<Toy> list = JsonSerializer.Deserialize<List<Toy>>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return list;
    }

    public async Task DeleteAsync(int id)
    {
        HttpResponseMessage responseMessage = await client.DeleteAsync($"/Child/Toys/{id}");
        string response = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
        
    }
}