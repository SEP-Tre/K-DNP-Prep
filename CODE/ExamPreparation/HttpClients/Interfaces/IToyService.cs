using Domain.Domain;

namespace HttpClients.Interfaces;

public interface IToyService
{
    Task<Toy> AssignToy(int id, Toy toy);

    Task<List<Toy>> GetAll();
    Task DeleteAsync(int id);
}