using System;
using API.DTOs;
using API.Extensions;
using API.Models;
using AutoMapper;


namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDto>()
        // for member (for some property)
        // nullforgiving just to get rid of compile warning (automapper will automatically set value to null)   
            .ForMember(
                destinantion => destinantion.PhotoUrl, 
                option=> option.MapFrom(source => source.Photos.FirstOrDefault(p=>p.IsMain)!.Url))
        // the reason for this is to reduce the SELECT query to database (might be useful for large database tables)
        // below result
            .ForMember(d=>d.Age, o=>o.MapFrom(s => s.DateOfBirth.CalculateAge()));
            
        CreateMap<Photo, PhotoDto>();
    }
}


/*  BEFORE (17 cols)
    SELECT "a"."IdUser", "a"."UserName", "a"."City", "a"."Country", "a"."CreatedAt", "a"."DateOfBirth",
           "a"."Gender", "a"."Introduction", "a"."KnownAs", "a"."LastActive", "a"."LookingFor", "a"."PasswordHash", 
           "a"."PasswordSalt", "p"."Id", "p"."Url", "p"."IsMain", 
          (
            SELECT "p0"."Url"
            FROM "Photo" AS "p0"
            WHERE "a"."IdUser" = "p0"."AppUserId" AND "p0"."IsMain"
            LIMIT 1
          )
    FROM "AppUser" AS "a"
    LEFT JOIN "Photo" AS "p" ON "a"."IdUser" = "p"."AppUserId"
    ORDER BY "a"."IdUser"

   AFTER  (15 cols)
   SELECT "a"."IdUser", "a"."UserName", "a"."KnownAs", "a"."CreatedAt", "a"."LastActive", "a"."Gender",
          "a"."Introduction", "a"."LookingFor", "a"."City", "a"."Country", "p"."Id", "p"."Url", "p"."IsMain", 
          (
            SELECT "p0"."Url"
            FROM "Photo" AS "p0"
            WHERE "a"."IdUser" = "p0"."AppUserId" AND "p0"."IsMain"
            LIMIT 1
          ), 
          "a"."DateOfBirth"
      FROM "AppUser" AS "a"
      LEFT JOIN "Photo" AS "p" ON "a"."IdUser" = "p"."AppUserId"
      ORDER BY "a"."IdUser"
*/
