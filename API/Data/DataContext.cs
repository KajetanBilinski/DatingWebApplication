using System;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> AppUsers { get; set; }
    //public DbSet<Photo> Photos { get; set; } not needed bcs we wont search for photo by ID
}
