using API.Controllers;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API;

public class BuggyController(DataContext context) : BaseApiController
{
    [Authorize]
    [HttpGet("auth")]
    public ActionResult<string> GetAuth()
    {
        return "secret text";
    }

    [HttpGet("not-found")]
    public ActionResult<AppUser> GetNotFound()
    {
        var thing = context.AppUsers.Find(-1);
        if(thing == null) return NotFound();
        return thing;
    }

    [HttpGet("server-error")]
    public ActionResult<AppUser> GetServerError()
    {
        var thing = context.AppUsers.Find(-1) ?? throw new Exception("A bad thing occured");
        return thing;
    }

    [HttpGet("bad-request")]
    public ActionResult<AppUser> GetBadRequest()
    {
        return BadRequest("Bad request");
    }

}