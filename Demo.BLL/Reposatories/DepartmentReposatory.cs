using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using Demo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Reposatories
{
    public class DepartmentReposatory : GenericReposatory<Department> , IDepartmentReposatory
    {
        private readonly MVCAppDBContext context;

        public DepartmentReposatory(MVCAppDBContext context) : base(context) 

        {
            this.context = context; 

            /*MVCAppDBContext context = new MVCAppDBContext()*/
            ; //مينفعش عشان مش هعرف اباصيله الاوبشن وبالتالي هتتجة الى الديبندنسي انجيكشن  
            
        }
        public int Add(Department department)
        {
            context.Add(department);
            return context.SaveChanges(); //returns int that's why add is int type  
        }

        public int Delete(Department department)
        {
            context.Remove(department);
            return context.SaveChanges();
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            var departments = context.Departments.ToList();
                return departments;
        }

        public Department GetDepartmentById(int? id)
        {
            var departments = context.Departments.Where(s=>s.Id == id).FirstOrDefault();
            return departments;
        }

        public int Update(Department department)
        {
            context.Update(department);
            return context.SaveChanges();
        }
    }
}
