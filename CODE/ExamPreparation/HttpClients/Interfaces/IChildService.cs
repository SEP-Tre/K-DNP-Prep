using Domain.Domain;
using Domain.Dto;

namespace HttpClients.Interfaces;

public interface IChildService
{
   Task<Child> AddAsync(ChildCreationDto dto);
}