using Company.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Company.Repository.Base
{
    public class MainRepo<T> : IRepository<T> where T : class
    {
        public MainRepo(DataBase dataBase)
        {
            this.dataBase = dataBase;  
                
        }
        private readonly DataBase dataBase;

        public IEnumerable<T> GetAll()
        {
            return dataBase.Set<T>().ToList();
        }

        public IEnumerable<T> GetAll(params string[] agers)
        {
            IQueryable<T> query=dataBase.Set<T>();
            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                    
                }
            }
            return query.ToList();
        }
        public async Task<IEnumerable<T>> GetAllAsync(params string[] agers)
        {
            IQueryable<T> query = dataBase.Set<T>();
            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);

                }
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dataBase.Set<T>().ToListAsync();
        }

        public T GetById(int Id)
        {
            return dataBase.Set<T>().Find( Id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dataBase.Set<T>().FindAsync(); 
        }

        public T select(Expression<Func<T, bool>> match)
        {
            return dataBase.Set<T>().SingleOrDefault(match);
        }
    }
}
