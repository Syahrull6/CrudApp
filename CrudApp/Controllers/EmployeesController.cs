using CrudApp.Data;
using CrudApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeRepository _repository;

        public EmployeesController(EmployeeRepository repository)
        {
            _repository = repository;
        }

        // GET: Employees
        public IActionResult Index()
        {
            var employees = _repository.GetAllEmployees();
            return View(employees);
        }

        // GET: Employees/Details/5
        public IActionResult Details(int id)
        {
            var employee = _repository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int id)
        {
            var employee = _repository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repository.UpdateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int id)
        {
            var employee = _repository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }
    }
}