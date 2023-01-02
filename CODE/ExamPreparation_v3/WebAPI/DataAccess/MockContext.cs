using Microsoft.EntityFrameworkCore;
using Model;

namespace WebAPI.DataAccess;

public class MockContext : DbContext
{
    public DbSet<MockModel> MockModels { get; set; }
    public DbSet<MockModelThree> MockModelThrees { get; set; }
    //cd WebAPI
    //dotnet ef migrations add InitalCreate
    //dotnet ef database update
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = Mock.db");
    }
    //Todo
    //1.Add dbContext in Program.cs
    //2.Create one mock method for adding in context
    //3.Create one endpoint for adding
    //4.Create Blazor for adding
}