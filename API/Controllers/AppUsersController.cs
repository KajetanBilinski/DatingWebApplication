using System;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AppUsersController(DataContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetAppUsers()
    {
        var appUsers = await context.AppUsers.ToListAsync();

        return Ok(appUsers);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AppUser>> GetAppUser(int id)
    {
        var appUser = await context.AppUsers.FindAsync(id);

        if(appUser == null) return NotFound();

        return appUser;
    }
}
