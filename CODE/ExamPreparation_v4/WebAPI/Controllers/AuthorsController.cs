using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;
using WebAPI.DataAccess;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class AuthorsController:ControllerBase
{
    private readonly AuthorContext context;

    public AuthorsController(AuthorContext context)
    {
        this.context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Author>> AddAsync(Author author)
    {
        try
        {
            ValidateAuthor(author);
            EntityEntry<Author> savedItem = await context.Authors.AddAsync(author);
            await context.SaveChangesAsync();
            return Ok(savedItem.Entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return BadRequest(e.Message);
        }
    }

    private static void ValidateAuthor(Author author)
    {
        if (author.FirstName.Length > 15 || author.LastName.Length>15)
        {
            throw new Exception("Both first and last name has to have 15 or less characters.");
        }
    

        else if (string.IsNullOrEmpty(author.FirstName) || 
                 string.IsNullOrEmpty(author.LastName))
        {
            throw new Exception("Names cannot be null or empty.");
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Author>>> GetAsync()
    {
        try
        {
            IQueryable<Author> query = context.Authors.Include(author => author.Books).AsQueryable();
            List<Author> result = await query.ToListAsync();
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}