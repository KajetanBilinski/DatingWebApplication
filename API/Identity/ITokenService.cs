using System;
using API.Models;

namespace API.Identity;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
