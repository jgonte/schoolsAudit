using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SchoolsAuditDomainModel.Schools;
using System;
using System.Linq;

namespace SchoolsAudit.ViewModels
{
    public class DocumentViewModel
    {
        public DocumentViewModel(Document document)
        {
            Id = document.Id;

            Label = document.Label;

            UserId = document.UserId;
        }

        public DocumentViewModel()
        {
        }

        public Document GetModel()
        {
            return new Document
            {
                Id = Id,
                Label = Label,
                UserId = UserId,
                FileName = Content.FileName,
                FileType = Content.ContentType,
                FileSize = Content.Length,
                FileContent = Content.GetContent()
            };
        }

        #region Attribute members

            public int? Id { get; set; }

            [StringLength(255)]
            public string Label { get; set; }

            public int? UserId { get; set; }

        #endregion

        #region Special attribute members

            public IFormFile Content { get; set; }

        #endregion

    }
}