using Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Entity
{
    public class DataBase:DbContext
    {
        public DataBase(DbContextOptions<DataBase>options):base(options)
        {    
        }
        public virtual DbSet<Employee> Employees{ get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;DataBase=HR;Trusted_Connection=True;Trust Server Certificate=True;");
       }
    }
}
