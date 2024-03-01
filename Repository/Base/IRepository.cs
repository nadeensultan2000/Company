using System.Linq.Expressions;
namespace Company.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        T select(Expression<Func<T,bool>> match);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(params string[] agers);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task <IEnumerable<T>> GetAllAsync(params string[] agers);
    }
}
