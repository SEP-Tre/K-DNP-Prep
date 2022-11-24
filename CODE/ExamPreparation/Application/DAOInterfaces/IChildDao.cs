using Domain.Domain;

namespace Application.DAOInterfaces;

public interface IChildDao
{
    Task<Child> AddAsync(Child child);
}