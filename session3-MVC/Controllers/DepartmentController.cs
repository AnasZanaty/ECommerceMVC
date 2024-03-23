using Demo.BLL.Interfaces;
using Demo.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace session3_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ILogger<DepartmentController> lOGGER;

        //private readonly IDepartmentReposatory departmentReposatory;
        //private readonly IEmployeeReposatory employeReposatory;

        private readonly IUnitOfWork unitOfWork;

        public DepartmentController(/*IDepartmentReposatory departmentReposatory , */
                                    ILogger<DepartmentController>lOGGER, IUnitOfWork unitOfWork
                                    //, IEmployeeReposatory employeReposatory
                                    )
        {
            //this.departmentReposatory = departmentReposatory;
            
            this.lOGGER = lOGGER;
            this.unitOfWork = unitOfWork;
            //this.employeReposatory = employeReposatory;
        }

        public IActionResult Index()
        {
            var departments = unitOfWork.DepartmentReposatory.GetAll();
           
            ViewData["Messagee"] = "Hello from view data";
           

            //على مستوى الريكويست بس
            ViewBag.message = "Hello from viewbag";

            
            
            return View(departments);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.DepartmentReposatory.Add(department);
                TempData["message"] = "Department created";
                return RedirectToAction("Index");

            }
            return View(department);

        }

        //logger using
        public IActionResult Details(int? id)
        {
            try
            {
                if (id is null) //عشان لو حد شال ال id من فوق 
                    return NotFound();
                var department = unitOfWork.DepartmentReposatory.GetById(id);
            department.Name = "HR3";
                if (department is null)
                    return NotFound();

                return View(department);
            }
            catch (Exception ex)
            {
                lOGGER.LogError(ex.Message);
                return RedirectToAction("Error", "Home");
            }
         

        }


        
        public IActionResult Update(int?id )
        {
            if (id is null) 
                return NotFound();
            var department = unitOfWork.DepartmentReposatory.GetById(id);
            if (department is null)
                return NotFound();

            return View(department);
        }

        [HttpPost]
        public IActionResult Update(int id , Department department)
        {
            if (id != department.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                unitOfWork.DepartmentReposatory.Update(department);
                return RedirectToAction("Index");
            }
                

            return View(department);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var department = unitOfWork.DepartmentReposatory.GetById(id);
            
            if (department is null)
                return NotFound();

            unitOfWork.DepartmentReposatory.Delete(department);
            return RedirectToAction("Index");




        }
    }
}
