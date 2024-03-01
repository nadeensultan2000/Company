using Company.Entity;
using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace Company.Controllers
{
    public class EmployeeController : Controller

    {
        public EmployeeController(DataBase _dataBase, IHostingEnvironment hosting)
        {
            this._dataBase = _dataBase;  
            this.hosting = hosting; 
        }
        private readonly DataBase _dataBase;
        private readonly IHostingEnvironment hosting;


        public IActionResult Index()
        {
            IEnumerable<Employee> employees = _dataBase.Employees.Include(c => c.Department).ToList();
            return View(employees);
        }
        public void createSelectList(int selectId = 1)
        {
            IEnumerable<Department> departments = _dataBase.Departments.ToList();
            SelectList items = new SelectList(departments, "Dept_id", "Dept_Name", selectId);
            ViewBag.DeptList = items;
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0) { return NotFound(); }
            var employee = _dataBase.Employees.Find(Id);
            if (employee == null) { return NotFound(); }

            else
            {
                createSelectList();
                return View("Delete", employee);
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee employee)
        {

            _dataBase.Employees.Remove(employee);

            _dataBase.SaveChanges();

            return RedirectToAction("Index");




        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0) { return NotFound(); }
            var employee = _dataBase.Employees.Find(Id);
            if (employee == null) { return NotFound(); }

            else
            {
                createSelectList();
                return View(employee);
            }
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (employee.Name == null)
            {
                ModelState.AddModelError("Name", "Name is required");
            }

            {
                _dataBase.Employees.Update(employee);
                _dataBase.SaveChanges();

                return RedirectToAction("Index");
            }

        }
        public IActionResult New()
        {
            createSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Employee employee)
        {
            if (employee.Name == "0")
            {
                ModelState.AddModelError("Name", "Name can't equal 0");
            }
            if (ModelState.IsValid)
            {
                string filename=string.Empty;
                if(employee.clientfile != null)
                {
                    string myupload = Path.Combine(hosting.WebRootPath, "images");
                    filename = employee.clientfile.FileName;
                    string fullpath= Path.Combine(myupload, filename);  
                    employee.clientfile.CopyTo(new FileStream(fullpath,FileMode.Create));
                    employee.ImagePath = filename;
                   
                } 
               
                _dataBase.Employees.Add(employee);
                _dataBase.SaveChanges();
                TempData["successData"] = "Employee has been added successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }
        public ActionResult Details(int Id)
        {
            var employee = _dataBase.Employees.Find(Id);
            IEnumerable<Employee> employees = _dataBase.Employees.Include(c => c.Department).ToList();


            return View("Details", employee);
        }
    }
}
