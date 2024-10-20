using API.DTOs;
using API.Models;
using AutoMapper.Execution;

namespace API.Identity;

public interface IUserRepository
{
    void Update(AppUser user);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<AppUser?> GetUserByIdAsync(int id);
    Task<AppUser?> GetUserByUsernameAsync(string username);
    Task<MemberDto?> GetMemberAsync(string username);
    Task<IEnumerable<MemberDto>?> GetMembersAsync();

}