using System;
using API.Data;
using API.DTOs;
using API.Identity;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class AppUsersController(IUserRepository userRepository) : BaseApiController
{

    //[AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetAppUsers()
    {
        // var appUsers = await userRepository.GetUsersAsync();

        // var appUsersToReturn = mapper.Map<IEnumerable<MemberDto>>(appUsers);
        var appUsers = await userRepository.GetMembersAsync();

        return Ok(appUsers);
    }

    //[Authorize]
    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetAppUser(string username)
    {
        // var appUser = await userRepository.GetUserByUsernameAsync(username);
        var appUser = await userRepository.GetMemberAsync(username);

        if(appUser == null) return NotFound();
        
        return appUser;

        // return mapper.Map<MemberDto>(appUser);
    }
}
