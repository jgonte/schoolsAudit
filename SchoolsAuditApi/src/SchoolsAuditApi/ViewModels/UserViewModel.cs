using SchoolsAuditDomainModel.Membership;
using SchoolsAuditDomainModel.Schools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SchoolsAudit.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(User user, List<School> schools)
        {
            Id = user.Id;

            Documents = user.Documents
                .Select(document => 
                {
                    return new DocumentViewModel(document);
                })
                .ToList();

            Schools = schools.Select(school => 
            {
                return new SchoolViewModel(school);
            }).ToList();
        }

        public UserViewModel()
        {
        }

        public User GetModel()
        {
            return new User
            {
                Id = Id.Value
            };
        }

        #region Attribute members

            public int? Id { get; set; }

        #endregion

        #region Linked view model members

            public ICollection<SchoolViewModel> Schools { get; set; } = new List<SchoolViewModel>();

            public ICollection<DocumentViewModel> Documents { get; set; } = new List<DocumentViewModel>();

        #endregion

    }
}