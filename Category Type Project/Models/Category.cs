using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Category_Type_Project.Models
{
    public class Category
    {
       public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public bool CanScale { get; set; } = true;
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public CategoryType Type { get; set; }

        public string? CreatedBy { get; set; }
    }
}
