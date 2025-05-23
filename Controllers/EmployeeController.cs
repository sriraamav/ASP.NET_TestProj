using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _repository;

        public EmployeeController(IConfiguration configuration)
        {
            _repository = new EmployeeRepository(configuration);
        }

        // READ
        public IActionResult Index()
        {
            var employees = _repository.GetAllEmployees(); // Calls stored procedure
            return View(employees);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _repository.AddEmployee(emp); 
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var emp = _repository.GetEmployeeById(id);
            if (emp == null)
                return NotFound();

            return View(emp);
        }

        // EDIT (POST)
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _repository.EditEmployee(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            _repository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
