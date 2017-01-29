using SchoolsAuditDomainModel.Membership;
using System;
using System.Linq;

namespace SchoolsAudit.ViewModels
{
    public class UserLoginViewModel
    {
        #region Attribute members

            public int? ProviderKey { get; set; }

            public int? LoginProvider { get; set; }

        #endregion

    }
}