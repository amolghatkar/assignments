using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CornerStoneWeb.Models.ViewModel
{
    public class SignUpViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter User Name")]
        [Remote(action: "UserNameIsExist","Account")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Mobile Number")]
        public long Mobile { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; }

        [Display(Name ="Remember Me")]
        public bool? IsRemember { get; set; }
    }
}
