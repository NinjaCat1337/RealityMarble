using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealityMarble.Web.Models
{
    public class ChangePasswordByAdminModel
    {
        [Required]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string Password { get; set; }
    }

    public class ChangeEmailByAdminModel
    {
        [Required]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ChangeUserNameByAdminModel
    {
        [Required]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}