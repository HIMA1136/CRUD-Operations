using Category_Type_Project.Models;

namespace Category_Type_Project.Repositories
{
    public class CategoryTypesRepository : GenericRepository<CategoryType>, ICategoryTypesRepository
    {
        public CategoryTypesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
