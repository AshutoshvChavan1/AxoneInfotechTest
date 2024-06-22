using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticalTest.Data;
using PracticalTest.Models.Domain;
using PracticalTest.Models;

namespace PracticalTest.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddEmployeeViewModel
            {
                Employees = _context.Employees.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    EmployeeName = model.EmployeeName,
                    ShortName = model.ShortName,
                    DateOfBirth = model.DateOfBirth,
                    Age = DateTime.Now.Year - model.DateOfBirth.Year,
                    Gender = model.Gender,
                    LanguageKnown = string.Join(",", model.LanguageKnown)
                };

                _context.Employees.Add(employee);
                _context.SaveChanges();

                return RedirectToAction("Add");
            }

            model.Employees = _context.Employees.ToList();
            return View(model);
        }

        //[HttpPost]
        //public IActionResult Update(int id, AddEmployeeViewModel model)
        //{
        //    var employee = _context.Employees.Find(id);
        //    if (employee != null)
        //    {
        //        employee.EmployeeName = model.EmployeeName;
        //        employee.ShortName = model.ShortName;
        //        employee.DateOfBirth = model.DateOfBirth;
        //        employee.Age = DateTime.Now.Year - model.DateOfBirth.Year;
        //        employee.Gender = model.Gender;
        //        employee.LanguageKnown = string.Join(",", model.LanguageKnown);

        //        _context.SaveChanges();
        //    }
        //    return RedirectToAction("Add");
        //}
        [HttpPost]
        public IActionResult Update(int id, AddEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _context.Employees.Find(id);
                if (employee != null)
                {
                    employee.EmployeeName = model.EmployeeName;
                    employee.ShortName = model.ShortName;
                    employee.DateOfBirth = model.DateOfBirth;
                    employee.Age = DateTime.Now.Year - model.DateOfBirth.Year;
                    employee.Gender = model.Gender;
                    employee.LanguageKnown = string.Join(",", model.LanguageKnown);

                    _context.SaveChanges();
                    return RedirectToAction("Add");
                }
            }

            model.Employees = _context.Employees.ToList();
            return View("Add", model);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return RedirectToAction("Add");
        }

        [HttpGet]
        public JsonResult GetData(int id)
        {
            var employee = _context.Employees.Find(id);
            return Json(employee);
        }
    }
}
