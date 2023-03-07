using System.ComponentModel.DataAnnotations;
using Category_Type_Project.Models;

namespace Category_Type_Project.ViewModels
{
    public class CategorisFormViewModel
    {

        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public bool CanScale { get; set; } = true;
        [Display(Name ="CategoryType")]
        public int TypeId { get; set; }
        public IEnumerable<CategoryType>? Types { set; get; }
        

    }
}
