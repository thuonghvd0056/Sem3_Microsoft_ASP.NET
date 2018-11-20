using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Assignment.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(40, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(40, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Plese confirm password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}