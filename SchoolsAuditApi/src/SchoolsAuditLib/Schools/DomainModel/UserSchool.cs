using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SchoolsAuditDomainModel.Membership;

namespace SchoolsAuditDomainModel.Schools
{
    public class UserSchool
    {
        public int UserId { get; set; }

        public int SchoolId { get; set; }

        public virtual User User { get; set; }

        public virtual School School { get; set; }

    }
}