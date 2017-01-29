using System;
using System.Collections;
using System.Collections.Generic;
using SchoolsAudit.ViewModels;

namespace SchoolsAudit.Repository
{
    public interface IUserViewModelRepository
    {
        #region UserViewModel Persistence Methods

        #endregion

        #region Schools Persistence Methods

            bool LinkSchool(UserSchoolViewModel userSchool);

            bool UnlinkSchool(int? userId, int? schoolId);

        #endregion

        #region Documents Persistence Methods

            bool AddDocument(int? userId, DocumentViewModel document);

            bool RemoveDocument(int? userId, int? documentId);

        #endregion

    }
}