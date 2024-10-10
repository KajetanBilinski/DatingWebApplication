using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
{
    //[Required]
    //public required string Username { get; set; }
    // required field gives weird error on client

    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    [StringLength(20, MinimumLength = 4)]
    public string Password { get; set; } = string.Empty;
}
