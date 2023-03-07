using System.ComponentModel.DataAnnotations;

namespace Category_Type_Project.ViewModels
{
    public class RegisterViewModel
    {
        [MaxLength(20)]
        [Display(Name ="الاسم الاول")]
        public string FirstName { set; get; }
        [MaxLength(20)]
        [Display(Name = "الاسم الثاني")]
        public string LastName { set; get; }
        [EmailAddress]
        public string Email { set; get; }
        [DataType(DataType.Password)]
        public string Password { set; get; }
        [DataType(DataType.Password)]
        [Display(Name="Confirm password")]
        [Compare("Password",ErrorMessage ="Password and confirmation password do not match.")]
        public string ConfirmPassword { set; get; }






    }
}
