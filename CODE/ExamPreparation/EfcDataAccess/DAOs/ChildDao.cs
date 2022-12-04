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

    public async Task<List<int>> GetAllIds()
    {
        IAsyncEnumerable<Child> allChildren =  context.Children.AsAsyncEnumerable();
        List<Int32> allIds = new List<int>();
        await foreach (var child in allChildren)
        {
            allIds.Add(child.Id);
        }

        return allIds;
    }

    public async Task<List<Child>> GetAll()
    {
        IAsyncEnumerable<Child> allChildren =  context.Children.AsAsyncEnumerable();
        List<Child> allKids = new List<Child>();
        await foreach (var child in allChildren)
        {
            allKids.Add(child);
        }

        return allKids;
    }
}