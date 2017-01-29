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
    public class SchoolViewModelRepository : ISchoolViewModelRepository
    {
        private readonly ApplicationDbContext _context;

        public SchoolViewModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region SchoolViewModel Persistence Methods

            public SchoolViewModel GetById(int? schoolId)
            {
                var viewModel = _context.Schools
                    .AsNoTracking()
                    .Where(e => e.Id == schoolId)
                    .Select(e => new SchoolViewModel(e))
                    .SingleOrDefault();

                return viewModel;
            }

            public IEnumerable<SchoolViewModel> GetAll()
            {
                var viewModel = _context.Schools
                    .AsNoTracking()
                    .Select(e => new SchoolViewModel(e))
                    .ToList();

                return viewModel;
            }

            public void Save(SchoolViewModel school)
            {
            }

            public void Create(SchoolViewModel school)
            {
                var model = school.GetModel();

                _context.Schools.Add(model);

                _context.SaveChanges();
            }

            public bool Update(SchoolViewModel school)
            {
                var entity = _context.Schools.SingleOrDefault(p => p.Id == school.Id);

                if (entity == null)
                {
                    return false;
                }

                var model = school.GetModel();

                _context.Schools.Update(model);

                _context.SaveChanges();

                return true;
            }

            public bool Delete(int? schoolId)
            {
                var school = _context.Schools.SingleOrDefault(p => p.Id == schoolId);

                if (school == null)
                {
                    return false;
                }

                _context.Schools.Remove(school);

                _context.SaveChanges();

                return true;
            }

        #endregion

    }
}