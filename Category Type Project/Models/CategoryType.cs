using System.ComponentModel.DataAnnotations;

namespace Category_Type_Project.Models
{
    public class CategoryType
    {

        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }    
    }
}
