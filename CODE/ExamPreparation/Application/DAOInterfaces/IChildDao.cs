using Domain.Domain;

namespace Application.DAOInterfaces;

public interface IChildDao
{
    Task<Child> AddAsync(Child child);

    Task<List<Int32>> GetAllIds();

    Task<List<Child>> GetAll();
}