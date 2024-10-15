using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;
public class Photo
{
    public int Id {get;set;}
    public required string Url {get;set;}
    public bool IsMain { get; set; }
    public string? PublicId { get; set; }
    //Navigation properties (needed to make required one to many)
    public int AppUserId {get;set;}
    public AppUser AppUser {get;set;} = null!; // cannot use required due to EF conventions
}