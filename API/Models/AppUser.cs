using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Extensions;
using API.Models;

namespace API.Models;

[Table("AppUser")]
public class AppUser
{
    [Key]
    public int IdUser { get; set; }
    public required string UserName { get; set; }
    public byte[] PasswordHash { get; set; } = [];
    public byte[] PasswordSalt { get; set; } = [];
    public DateOnly DateOfBirth {get; set;}
    public required string KnownAs { get; set; }
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    public DateTime LastActive {get; set;} = DateTime.UtcNow;
    public required string Gender {get; set;} 
    public string? Introduction {get; set;} 
    public string? LookingFor {get; set;} 
    public required string City {get; set;} 
    public required string Country {get; set;} 
    public List<Photo> Photos {get; set;} = [];

    public int GetAge()
    {
        return DateOfBirth.CalculateAge();
    }
}

