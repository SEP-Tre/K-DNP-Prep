using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

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
        optionsBuilder.UseSqlite("Data Source = MockTwo.db");
    }
}