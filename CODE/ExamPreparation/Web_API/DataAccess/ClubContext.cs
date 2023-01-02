using Microsoft.EntityFrameworkCore;
using Web_API.models;

namespace Web_API.DataAccess;

public class ClubContext : DbContext
{
    public DbSet<Player> Player { get; set; }
    public DbSet<Team> Team { get; set; }
    //cd WebAPI
    //dotnet ef migrations add InitalCreate
    //dotnet ef database update

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = Club.db");
    }
}