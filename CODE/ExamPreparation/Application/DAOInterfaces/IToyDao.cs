using Domain.Domain;

namespace Application.DAOInterfaces;

public interface IToyDao
{
   Task<Toy> AssignToy(int id,Toy toy);
   Task<List<Toy>> GetAll();
   Task Delete(int id);
}