using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SchoolsAuditDomainModel.Schools
{
    public class School
    {
        public enum SchoolTypes
        {
            Public = 0,
            Private = 1,
            Charter = 2
        }
        public enum SchoolLevels
        {
            Elementary = 0,
            Middle = 1,
            HighSchool = 2,
            University = 3
        }
        public int? Id { get; set; }

        public SchoolTypes? Type { get; set; }

        public SchoolLevels? Level { get; set; }

        public string Name { get; set; }

    }
}