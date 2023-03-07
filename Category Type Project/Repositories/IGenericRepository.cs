namespace Category_Type_Project.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(string[] includes = null);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        void Delete(T entity);

    }
}
