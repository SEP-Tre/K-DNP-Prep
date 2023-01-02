using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Web_API.DataAccess;
using Web_API.models;

namespace Web_API.Controllers;
[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly ClubContext context;

    public PlayerController(ClubContext context)
    {
        this.context = context;
    }
    
    [HttpPost, Route("{TeamName}")]
    public async Task<ActionResult<Player>> AddAsync(Player player, [FromRoute] string TeamName)
    {
        try
        {
             //= await context.Player.AddAsync(player);
             EntityEntry<Player> savedPlayer =  await context.Player.AddAsync(player);
             await context.SaveChangesAsync();
            Team team = await context.Team.FindAsync(TeamName);
            if (team != null)
            {
               team.Players.Add(savedPlayer.Entity);
               
               context.Team.Attach(team);
               await context.SaveChangesAsync();
            }
            return Ok(savedPlayer.Entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete, Route("{Name}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] string Name)
    {
        try
        {
            context.Player.Remove(context.Player.Find(Name));
            await context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        } 
    }
    
    

}