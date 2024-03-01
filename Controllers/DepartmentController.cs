using Company.Models;
using Company.Repository;
using Company.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    public class DepartmentController : Controller
    {

        public DepartmentController(IUnitOfWork unit)
        {
          this.unit=unit;
            
        }
     
        private readonly IUnitOfWork unit;


        public async Task<IActionResult> Index()
        {
            var oneDept = unit.Departments.select(x => x.Dept_Name == "Computer Science");
            return View( await unit.Departments.GetAllAsync());
        }
        public IActionResult Edit() { return View(); }    
    }
}
