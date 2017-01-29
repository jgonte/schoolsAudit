using System;
using System.Collections;
using System.Collections.Generic;
using SchoolsAudit.ViewModels;

namespace SchoolsAudit.Repository
{
    public interface ISchoolViewModelRepository
    {
        #region SchoolViewModel Persistence Methods

            SchoolViewModel GetById(int? schoolId);

            IEnumerable<SchoolViewModel> GetAll();

            void Save(SchoolViewModel school);

            void Create(SchoolViewModel school);

            bool Update(SchoolViewModel school);

            bool Delete(int? schoolId);

        #endregion

    }
}