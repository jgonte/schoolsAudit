using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SchoolsAuditDomainModel.Schools;
using SchoolsAuditDomainModel.Persistence;
using SchoolsAudit.ViewModels;

namespace SchoolsAudit.Repository
{
    public class DocumentViewModelRepository : IDocumentViewModelRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentViewModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region DocumentViewModel Persistence Methods

            public DocumentViewModel GetById(int? documentId)
            {
                var viewModel = _context.Documents
                    .AsNoTracking()
                    .Where(e => e.Id == documentId)
                    .Select(e => new DocumentViewModel(e))
                    .SingleOrDefault();

                return viewModel;
            }

            public IEnumerable<DocumentViewModel> GetAll()
            {
                var viewModel = _context.Documents
                    .AsNoTracking()
                    .Select(e => new DocumentViewModel(e))
                    .ToList();

                return viewModel;
            }

            public void Save(DocumentViewModel document)
            {
            }

            public void Create(DocumentViewModel document)
            {
                var model = document.GetModel();

                _context.Documents.Add(model);

                _context.SaveChanges();
            }

            public bool Update(DocumentViewModel document)
            {
                var entity = _context.Documents.SingleOrDefault(p => p.Id == document.Id);

                if (entity == null)
                {
                    return false;
                }

                var model = document.GetModel();

                _context.Documents.Update(model);

                _context.SaveChanges();

                return true;
            }

            public bool Delete(int? documentId)
            {
                var document = _context.Documents.SingleOrDefault(p => p.Id == documentId);

                if (document == null)
                {
                    return false;
                }

                _context.Documents.Remove(document);

                _context.SaveChanges();

                return true;
            }

        #endregion

    }
}