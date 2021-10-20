﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Examples.Charge.Domain.Aggregates.Identity
{
    public class Role : IdentityRole<int>
    {
        public List<UserRole> UserRoles { get; set; }
    }
}
