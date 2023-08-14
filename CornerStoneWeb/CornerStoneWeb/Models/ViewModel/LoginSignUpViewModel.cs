using System.ComponentModel.DataAnnotations;

namespace CornerStoneWeb.Models.ViewModel
{
    public class LoginSignUpViewModel
    {
        [Required(ErrorMessage = "Please Enter User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }        

        [Display(Name ="Remember Me")]
        public bool? IsRemember { get; set; }
    }
}
