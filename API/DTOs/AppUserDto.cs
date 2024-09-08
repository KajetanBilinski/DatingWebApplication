using System;

namespace API.DTOs;

public class AppUserDto
{
    public required string Username { get; set; }
    public required string Token { get; set; }
}
