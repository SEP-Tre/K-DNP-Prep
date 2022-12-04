using Application.DAOInterfaces;
using Domain.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class ToyDao : IToyDao
{
    private readonly KinderGardenContext context;

    public ToyDao(KinderGardenContext context)
    {
        this.context = context;
    }
    public async Task<Toy> AssignToy(int id,Toy toy)
    {
        toy.ChildId = id;
        EntityEntry<Toy> savedToy = await context.Toys.AddAsync(toy);
        await context.SaveChangesAsync();
        Child? childToAddToy = await context.Children.FindAsync(id);
        if (childToAddToy!=null)
        {
            childToAddToy.Toys.Add(savedToy.Entity);
        }
        return savedToy.Entity;
    }

    public async Task<List<Toy>> GetAll()
    {
        IAsyncEnumerable<Toy> allToys =  context.Toys.AsAsyncEnumerable();
        List<Toy> toys = new List<Toy>();
        await foreach (var toy in allToys)
        {
            toys.Add(toy);
        }

        return toys;
    }

    public async Task Delete(int id)
    {

        Toy? toy = await context.Toys.FindAsync(id);
        if (toy!=null)
        {
            context.Toys.Remove(toy);
            await context.SaveChangesAsync();
        }
        
    }
}