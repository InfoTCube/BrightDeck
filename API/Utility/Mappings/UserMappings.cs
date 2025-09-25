using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Utility.Mappings;

public static class UserMappings
{
    public static AppUser ToEntity(this UserForRegistrationDto from) =>
        new AppUser
        {
            UserName = from.UserName,
            Email = from.Email
        };
}