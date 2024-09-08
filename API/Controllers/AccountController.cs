using System;
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Identity;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult<AppUserDto>> Register (RegisterDto registerDto)
    {
        if(await UserExists(registerDto.Username)) return BadRequest("User exists");
        using var hmac = new HMACSHA512(); //Hash-based Message Authentication Code) – kod MAC z wmieszanym kluczem
        var user = new AppUser(){
            UserName = registerDto.Username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };
        context.AppUsers.Add(user);
        await context.SaveChangesAsync();
        return new AppUserDto
        {
            Username = user.UserName,
            Token = tokenService.CreateToken(user)
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<AppUserDto>> Login(LoginDto loginDto)
    {
        var user = await context.AppUsers.FirstOrDefaultAsync(u=>u.UserName.ToLower() == loginDto.Username.ToLower());

        if(user == null) return Unauthorized("Invalid username");

        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
        for(int i = 0; i<computedHash.Length; i++)
        {
            if(computedHash[i]!=user.PasswordHash[i]) return Unauthorized("Invalid password");
        }
        return new AppUserDto
        {
            Username = user.UserName,
            Token = tokenService.CreateToken(user)
        };
    }

    private async Task<bool> UserExists(string username)
    {
        return await context.AppUsers.AnyAsync(u=> u.UserName.ToLower() == username.ToLower());
    }
}
