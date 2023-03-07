using System.ComponentModel.DataAnnotations;

namespace Category_Type_Project.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress]
        public string Email { set; get; }
        [DataType(DataType.Password)]
        public string Password { set; get; }    
        public bool RememberMe { set; get; }
    }
}
