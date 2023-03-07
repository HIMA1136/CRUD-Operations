using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Category_Type_Project.Models
{
    public class AppUser:IdentityUser
    {
        [MaxLength(15)]
         public string FirstName { set; get; }
        [MaxLength(15)]
        public string LastName { set; get; }
    }
}
