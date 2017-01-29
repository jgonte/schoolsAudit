using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SchoolsAuditDomainModel.Schools
{
    public class Document
    {
        public int? Id { get; set; }

        public string Label { get; set; }

        public int? UserId { get; set; }

        public string FileName { get; set; }

        public string FileType { get; set; }

        public long? FileSize { get; set; }

        public byte[] FileContent { get; set; }

    }
}