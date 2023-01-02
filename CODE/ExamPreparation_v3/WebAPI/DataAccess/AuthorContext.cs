using Microsoft.EntityFrameworkCore;
using Model;

namespace WebAPI.DataAccess;

public class AuthorContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    //cd WebAPI
    //dotnet ef migrations add InitalCreate
    //dotnet ef database update
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = Author.db");
    }
}