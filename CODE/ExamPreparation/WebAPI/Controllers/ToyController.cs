using Application.DAOInterfaces;
using Domain.Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ToyController : ControllerBase
{
    private readonly IToyDao toyDao;

    public ToyController(IToyDao toyDao)
    {
        this.toyDao = toyDao;
    }

    [HttpPost]
    [Route("owner/{id:int}")]
    public async Task<ActionResult<Toy>> AddAsync([FromRoute]int id, Toy toy)
    {
        try
        {
            Toy savedToy = await toyDao.AssignToy(id,toy);
            return Ok(savedToy);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("All")]
    public async Task<List<Toy>> GetAllAsync()
    {
        try
        {
            List<Toy> toys = await toyDao.GetAll();
            return toys;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete]
    [Route("/Child/Toys/{toyId:int}")]
    public async Task DeleteAsync([FromRoute] int toyId)
    {
        try
        {
            await toyDao.Delete(toyId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
}