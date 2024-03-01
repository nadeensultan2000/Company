using Company.Models;
using Company.Repository.Base;

namespace Company.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Department> Departments { get; } 
        IRepository<Employee> Employees { get; }
        int CommitChanges();
    }
}
