using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SchoolsAuditDomainModel.Schools;

namespace SchoolsAuditDomainModel.Membership
{
    public class User : IdentityUser<int, UserClaim, UserRole, UserLogin>
    {
        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    }
}