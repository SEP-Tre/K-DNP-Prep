using Application.DAOInterfaces;
using Domain.Domain;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ChildController: ControllerBase
{
    private readonly IChildDao childDao;

    public ChildController(IChildDao childDao)
    {
        this.childDao = childDao;
    }

    [HttpPost]
    public async Task<ActionResult<Child>> AddAsync(ChildCreationDto dto)
    {
        try
        {
            Child toBeSavedChild = new Child();
            toBeSavedChild.Age = dto.Age;
            toBeSavedChild.Name = dto.Name;
            toBeSavedChild.Gender = dto.Gender;
            Child savedChild = await childDao.AddAsync(toBeSavedChild);
            return Ok(savedChild);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<List<int>> GetAllIds()
    {
        try
        {
            List<int> list = await childDao.GetAllIds();
            return list;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet]
    [Route("All")]
    public async Task<List<Child>> GetAllAsync()
    {
        try
        {
            List<Child> children = await childDao.GetAll();
            return children;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


}