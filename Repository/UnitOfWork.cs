
using Company.Entity;
using Company.Models;
using Company.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Company.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        public UnitOfWork(DataBase dataBase)
        {
            this.dataBase = dataBase;
            Departments=new MainRepo<Department>(dataBase);
            Employees = new MainRepo<Employee>(dataBase);

        }
        private readonly DataBase dataBase;

        public IRepository<Department> Departments {get; private set;}

        public IRepository<Employee> Employees { get; private set;}

        public int CommitChanges()
        {
            return dataBase.SaveChanges();
        }

        public void Dispose()
        {
            dataBase.Dispose();
        }
    }
}
