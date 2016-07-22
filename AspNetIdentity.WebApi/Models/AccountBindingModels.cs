using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.WebApi.Models
{
    public class AccountBindingModels
    {
    }

    public class CreateUserBindingModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Display(Name ="Role Name")]
        public string RoleName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage ="The {0} must be at least {2} characters long.", MinimumLength =6)]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage ="The password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }

    }

    public class ChangePasswordBingingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Current Password")]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage ="The {0} must be at least {2} characters long.", MinimumLength =6)]
        [Display(Name ="New Password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Confirm New Password")]
        [Compare("NewPassword", ErrorMessage ="The new password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}