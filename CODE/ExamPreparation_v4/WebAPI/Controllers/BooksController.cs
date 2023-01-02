using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;
using WebAPI.DataAccess;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController:ControllerBase
{
    private readonly AuthorContext context;

    public BooksController(AuthorContext context)
    {
        this.context = context;
    } 
    
    [HttpPost]
    [Route("{id:int}")]
    public async Task<ActionResult<Book>> AddAsync(Book book, [FromRoute] int id)
    {
        try
        {
            ValidateBook(book);
            book.AuthorId = id;
            EntityEntry<Book> savedItem = await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            Author author = await context.Authors.FindAsync(id);
            if (author!=null)
            {
                author.Books.Add(savedItem.Entity);
                context.Authors.Attach(author);
                await context.SaveChangesAsync();
            }
            return Ok(savedItem.Entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return BadRequest(e.Message);
        }
    }

    private static void ValidateBook(Book book)
    {
        if (string.IsNullOrEmpty(book.Title))
        {
            throw new Exception("Title cannot be empty.");
        }

        if (book.Title.Length > 40)
        {
            throw new Exception("Title cannot be longer than 40 characters.");
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetAsync()
    {
        try
        {
            return await context.Books.AsQueryable().ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete]
    public async Task<ActionResult> DeleteAsync([FromQuery] int isbn)
    {
        try
        {
            Book? book = await context.Books.FindAsync(isbn);
            context.Books.Remove(book!);
            await context.SaveChangesAsync();
            
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return BadRequest(e.Message);
        }
    }
    
}