using System;
using System.Collections;
using System.Collections.Generic;
using SchoolsAudit.ViewModels;

namespace SchoolsAudit.Repository
{
    public interface IDocumentViewModelRepository
    {
        #region DocumentViewModel Persistence Methods

            DocumentViewModel GetById(int? documentId);

            IEnumerable<DocumentViewModel> GetAll();

            void Save(DocumentViewModel document);

            void Create(DocumentViewModel document);

            bool Update(DocumentViewModel document);

            bool Delete(int? documentId);

        #endregion

    }
}