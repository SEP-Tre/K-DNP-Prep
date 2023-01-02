using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;
using WebAPI.DataAccess;
namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MockController:ControllerBase
{
    private readonly MockContext context;

    public MockController(MockContext context)
    {
        this.context = context;
    }

    [HttpPost]
    public async Task<ActionResult<MockModel>> AddAsync(MockModel item)
    {
        try
        {
            EntityEntry<MockModel> savedItem = await context.MockModels.AddAsync(item);
            await context.SaveChangesAsync();
            return Ok(savedItem.Entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

   
}