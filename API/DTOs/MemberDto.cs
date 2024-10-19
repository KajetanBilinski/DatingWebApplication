using System;

namespace API.DTOs;

public class MemberDto
{
    public int IdUser { get; set; }
    // required is causing problems with other tools, need to be optional
    // Automapper - even different casing is OK
    public string? Username { get; set; }
    public int Age {get; set;}
    public string? PhotoUrl {get; set;}
    public string? KnownAs { get; set; }
    public DateTime CreatedAt {get; set;}
    public DateTime LastActive {get; set;}
    public string? Gender {get; set;} 
    public string? Introduction {get; set;} 
    public string? LookingFor {get; set;} 
    public string? City {get; set;} 
    public string? Country {get; set;} 
    public List<PhotoDto>? Photos {get; set;}
}
