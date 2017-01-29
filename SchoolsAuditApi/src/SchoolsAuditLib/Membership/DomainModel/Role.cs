using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SchoolsAuditDomainModel.Membership
{
    public class Role : IdentityRole<int, UserRole, RoleClaim>
    {
    }
}