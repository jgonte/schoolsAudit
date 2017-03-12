using System.ComponentModel.DataAnnotations;

namespace SchoolsAudit.ViewModels
{
    public class RegisterUserViewModel
    {
        #region Attribute members

            [Required]
            public string Email { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        #endregion

        #region Entity attribute map members

            [Required]
            [StringLength(50, MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Compare("Password")]
            public string ConfirmPassword { get; set; }

        #endregion

    }
}