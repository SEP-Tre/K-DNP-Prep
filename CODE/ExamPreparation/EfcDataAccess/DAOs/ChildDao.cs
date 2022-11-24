using Application.DAOInterfaces;
using Domain.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class ChildDao : IChildDao
{
    private readonly KinderGardenContext context;

    public ChildDao(KinderGardenContext context)
    {
        this.context = context;
    }
    public async Task<Child> AddAsync(Child child)
    {
        
        EntityEntry<Child> savedChild =  await context.Children.AddAsync(child);
        await context.SaveChangesAsync();
        return savedChild.Entity;
    }
}