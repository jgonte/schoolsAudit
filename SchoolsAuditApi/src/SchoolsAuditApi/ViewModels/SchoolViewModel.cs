using System.ComponentModel.DataAnnotations;
using SchoolsAuditDomainModel.Schools;
using System;
using System.Linq;

namespace SchoolsAudit.ViewModels
{
    public class SchoolViewModel
    {
        public SchoolViewModel(School school)
        {
            Id = school.Id;

            Type = school.Type;

            Level = school.Level;

            Name = school.Name;
        }

        public SchoolViewModel()
        {
        }

        public School GetModel()
        {
            return new School
            {
                Id = Id,
                Type = Type,
                Level = Level,
                Name = Name
            };
        }

        #region Attribute members

            public int? Id { get; set; }

            public School.SchoolTypes? Type { get; set; }

            public School.SchoolLevels? Level { get; set; }

            [Required]
            [StringLength(100)]
            public string Name { get; set; }

        #endregion

    }
}