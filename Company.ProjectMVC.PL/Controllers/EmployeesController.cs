using Company.BLL.Interfaces;
using Company.BLL.Repositories;
using Company.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.ProjectMVC.PL.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeRepository _employeeRepository;

        public EmployeesController(EmployeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var employee = _employeeRepository.GetAll();

            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var count = _employeeRepository.Add(model);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);

        }

        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest();

            var employee = _employeeRepository.Get(id);

            if (employee is null) return NotFound();

            return View(employee);
        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null) return BadRequest();

            var employee = _employeeRepository.Get(id);

            if (employee is null) return NotFound();

            return View(employee);
        }


        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                var Count = _employeeRepository.Update(model);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();

            var employee = _employeeRepository.Get(id);

            if (employee is null) return NotFound();

            return View(employee);
        }



        [HttpPost]
        public IActionResult Delete(Employee model)
        {
            if (ModelState.IsValid)
            {
                var Count = _employeeRepository.Delete(model);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}
