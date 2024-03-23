using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using session3_MVC.Models;
using session3_MVC.wwwroot.Helper;

namespace session3_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IActionResult Index(string SearchValue ="")
        {
            
            if (string.IsNullOrEmpty(SearchValue))
            {
                var employees = unitOfWork.EmployeeReposatory.GetAll();

                //from employee to viewmodel

                var mappedemployee= mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
                return View(mappedemployee);
            }
            else
            {
                var employees = unitOfWork.EmployeeReposatory.search(SearchValue);
                var mappedemployee = mapper.Map<IEnumerable<EmployeeViewModel>>(employees);

                return View(mappedemployee);
            }
           
        }

        [HttpGet]
        public IActionResult Create() {

            ViewBag.Departments = unitOfWork.DepartmentReposatory.GetAll();

            return View();
         }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {

            //عشان احل مشكلة الناف بروبيرتي
            //employee.Department = unitOfWork.DepartmentReposatory.GetById(employee.DepartmentId);
           // ModelState["Department"].ValidationState=ModelValidationState.Valid;

            if (ModelState.IsValid)
            {
                //manual mapping

                //Employee employee = new Employee
                //{
                //    Name = employeeVM.Name,
                //    Address = employeeVM.Address,
                //    DepartmentId = employeeVM.DepartmentId,
                //    Email = employeeVM.Email,
                //    HireDate = employeeVM.HireDate,
                //    salary = employeeVM.salary,
                //    ImageUrl = employeeVM.ImageUrl

                //};

                //auto ma

                //from viewmodel to model

                var employee = mapper.Map<Employee>(employeeVM);
                employee.ImageUrl = DocumentSettings.UploadFile(employeeVM.Image, "images");

                unitOfWork.EmployeeReposatory.Add(employee);

                return RedirectToAction("Index");
            }
            ViewBag.Departments = unitOfWork.DepartmentReposatory.GetAll();

            return View(employeeVM);
        }
        public IActionResult Details(int? id)
        {
           
                if (id is null) //عشان لو حد شال ال id من فوق 
                    return NotFound();
                var employee = unitOfWork.EmployeeReposatory.GetById(id);
            //var mappedemployee = mapper.Map<IEnumerable<EmployeeViewModel>>(employee);
            if (employee is null)
                    return NotFound();
                
                return View(employee);
           
     

        }

        public IActionResult Update(int? id)
        {
         
            if (id is null)
                return NotFound();
            var employee = unitOfWork.EmployeeReposatory.GetById(id);

            if (employee is null)
                return NotFound();

            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(int id, Employee employee)
        {
          

            if (id != employee.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                unitOfWork.EmployeeReposatory.Update(employee);
                return RedirectToAction("Index");
            }


            return View(employee);
        }
        public IActionResult Delete(int? id)
        {
           
            if (id is null)
                return NotFound();

            var employee = unitOfWork.EmployeeReposatory.GetById(id);

            if (employee is null)
            {
                return NotFound();
            }
            unitOfWork.EmployeeReposatory.Delete(employee);
            return RedirectToAction("Index");




        }
    }
}
