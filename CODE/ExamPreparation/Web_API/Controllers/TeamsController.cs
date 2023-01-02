using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Web_API.DataAccess;
using Web_API.models;

namespace Web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamsController : ControllerBase
{
    private readonly ClubContext context;

    public TeamsController(ClubContext context)
    {
        this.context = context;
    }
    
    [HttpPost]
    public async Task<ActionResult<Team>> AddAsync(Team team)
    {
        try
        {
            EntityEntry<Team> savedTeam = await context.Team.AddAsync(team);
            await context.SaveChangesAsync();
            return Ok(savedTeam.Entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<List<Team>> GetAsync([FromQuery] int? ranking, [FromQuery] string? name)
    {
        try
        {
            List<Team> foundTeams = new List<Team>();
            if (ranking != null && name==null && ranking!=0)
            {
                IQueryable<Team> rankingsQuery = context.Team.Where(t => t.Ranking <= ranking);
                foundTeams = await rankingsQuery.ToListAsync();
            }
            else if (name != null && ranking == 0 && ranking!=null)
            {
                IQueryable<Team> namesQuery = context.Team.Where(t => t.TeamName.Contains(name));
                foundTeams = await namesQuery.ToListAsync();
            }
            else if (ranking != null && name!=null && ranking!=0)
            {
                IQueryable<Team> rankingsQuery = context.Team.Where(t => t.Ranking <= ranking);
                rankingsQuery = rankingsQuery.Where(t => t.TeamName.Contains(name));
                foundTeams = await rankingsQuery.ToListAsync();
            }
            else
            {
                foundTeams =  await context.Team.AsQueryable().ToListAsync();
            }

            
            List<Player> players = context.Player.AsQueryable().ToList();

                foreach (var foundTeam in foundTeams)
                {
                    foreach (var player in players)
                    {
                        Console.WriteLine($"{player.Name} team: {player.TeamName}");
                        if (foundTeam.TeamName.Equals(player.TeamName))
                        {
                            if (!foundTeam.Players.Contains(player))
                            {
                                foundTeam.Players.Add(player);
                            } 
                        }
                    }
                    if (foundTeam.Players==null)
                    {
                        Console.WriteLine("players null");
                    }
                    //List<Player> foundPlayers = new List<Player>();
                    //IQueryable<Player> playersQuery = context.Player.Where(p => p.Tea);
                    //Console.WriteLine(foundTeam.Players.Find(p => p.Salary > 0).Name);
                }
            
            
            return foundTeams;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}