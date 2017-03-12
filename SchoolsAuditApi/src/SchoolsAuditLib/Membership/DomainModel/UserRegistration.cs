using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SchoolsAuditDomainModel.Membership
{
    public class UserRegistration
    {
        public string Email { get; set; }

        public string Password { get; set; }

    }
}