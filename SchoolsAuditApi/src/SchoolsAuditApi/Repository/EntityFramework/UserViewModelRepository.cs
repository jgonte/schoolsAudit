using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SchoolsAuditDomainModel.Membership;
using SchoolsAuditDomainModel.Persistence;
using SchoolsAudit.ViewModels;

namespace SchoolsAudit.Repository
{
    public class UserViewModelRepository : IUserViewModelRepository
    {
        private readonly ApplicationDbContext _context;

        public UserViewModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region UserViewModel Persistence Methods

        #endregion

        #region Schools Persistence Methods

            public bool LinkSchool(UserSchoolViewModel userSchool)
            {
                _context.UsersSchools.Add(userSchool.GetModel());

                _context.SaveChanges();

                return true;
            }

            public bool UnlinkSchool(int? userId, int? schoolId)
            {
                var entity = _context.UsersSchools.SingleOrDefault(p => (p.UserId == userId &&
                    p.SchoolId == schoolId));

                if (entity == null)
                {
                    return false;
                }

                _context.UsersSchools.Remove(entity);

                _context.SaveChanges();

                return true;
            }

        #endregion

        #region Documents Persistence Methods

            public bool AddDocument(int? userId, DocumentViewModel document)
            {
                var entity = _context.Users.SingleOrDefault(p => p.Id == userId);

                if (entity == null)
                {
                    return false;
                }

                entity.Documents.Add(document.GetModel());

                _context.SaveChanges();

                return true;
            }

            public bool RemoveDocument(int? userId, int? documentId)
            {
                var entity = _context.Users.SingleOrDefault(p => p.Id == userId);

                if (entity == null)
                {
                    return false;
                }

                var document = _context.Documents.SingleOrDefault(p => p.Id == documentId);

                if (document == null)
                {
                    return false;
                }

                entity.Documents.Remove(document);

                _context.SaveChanges();

                return true;
            }

        #endregion

    }
}