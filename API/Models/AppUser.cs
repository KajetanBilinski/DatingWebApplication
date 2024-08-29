using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("AppUser")]
public class AppUser
{
    [Key]
    public int IdUser { get; set; }
    public required string UserName { get; set; }
}
