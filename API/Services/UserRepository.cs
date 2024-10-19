using System;
using API.Data;
using API.DTOs;
using API.Identity;
using API.Models;
using AutoMapper;
using AutoMapper.Execution;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class UserRepository(DataContext context, IMapper mapper) : IUserRepository
{
    public async Task<MemberDto?> GetMemberAsync(string username)
    {
        return await context.AppUsers
            .Where(u=>u.UserName==username)
            // queryable method from automapper for LINQ
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider) // location of mapping configuration (similar to AppDomain)
            .SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<MemberDto>?> GetMembersAsync()
    {
        return await context.AppUsers
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<AppUser?> GetUserByIdAsync(int id)
    {
        return await context.AppUsers.FindAsync(id);
    }

    public async Task<AppUser?> GetUserByUsernameAsync(string username)
    {
        return await context.AppUsers
        .Include(u=>u.Photos)
        .SingleOrDefaultAsync(u=>u.UserName==username.ToLower());
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await context.AppUsers
        .Include(u=>u.Photos)
        .ToListAsync();
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
