using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Company.Models
{
    public class Department
    {
        
        [Key]
        [DisplayName("Department Name")]
        public int Dept_id { get; set; }
     
        public  string Dept_Name { get; set; }  
        public IEnumerable<Employee>?Employees { get; set; }
            

    }
}
