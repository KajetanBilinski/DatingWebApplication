using System;
using API.Data;
using API.Identity;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class UserRepository(DataContext context) : IUserRepository
{
    public async Task<AppUser?> GetUserByIdAsync(int id)
    {
        return await context.AppUsers.FindAsync(id);
    }

    public async Task<AppUser?> GetUserByUsernameAsync(string username)
    {
        return await context.AppUsers.SingleOrDefaultAsync(u=>u.UserName==username.ToLower());
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await context.AppUsers.ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync()>0;
    }

    public void Update(AppUser user)
    {
        //explicitly tell EF that AppUser is modified (user is tracked anyways)
        context.Entry(user).State = EntityState.Modified; 
    }
}
