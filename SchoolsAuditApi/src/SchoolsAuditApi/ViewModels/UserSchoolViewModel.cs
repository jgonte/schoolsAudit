using System.ComponentModel.DataAnnotations;
using SchoolsAuditDomainModel.Schools;
using System;
using System.Linq;

namespace SchoolsAudit.ViewModels
{
    public class UserSchoolViewModel
    {
        public UserSchoolViewModel(UserSchool userSchool)
        {
            UserId = userSchool.UserId;

            SchoolId = userSchool.SchoolId;
        }

        public UserSchoolViewModel()
        {
        }

        public UserSchool GetModel()
        {
            return new UserSchool
            {
                UserId = UserId,
                SchoolId = SchoolId
            };
        }

        #region Attribute members

            [Required]
            public int UserId { get; set; }

            [Required]
            public int SchoolId { get; set; }

        #endregion

    }
}