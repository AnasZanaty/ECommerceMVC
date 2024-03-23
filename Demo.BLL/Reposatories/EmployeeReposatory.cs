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
    public class EmployeeReposatory : GenericReposatory<Employee> , IEmployeeReposatory
    {
        private readonly MVCAppDBContext context;

        public EmployeeReposatory(MVCAppDBContext context) : base(context)  //CONSTRUCTORCHAINING

        {
            this.context = context;

        }

        public IEnumerable<Employee> GetEmployeesByDepartmentName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> search(string name)
        {
           var emp= context.Employees.Where(emp=>emp.Name.Trim().ToLower().Contains(name.Trim().ToLower()));
            return emp;
        }
        //int IEmployeeReposatory.Add(Employee employee)
        //{
        //    context.Add(employee);
        //    return context.SaveChanges();
        //}

        //int IEmployeeReposatory.Delete(Employee employee)
        //{
        //    context.Remove(employee);
        //    return context.SaveChanges();
        //}

        //IEnumerable<Employee> IEmployeeReposatory.GetAllEmployee()
        //{
        //    var employees = context.Employees.ToList();
        //    return employees;
        //}

        //Employee IEmployeeReposatory.GetEmployeeById(int? id)
        //{
        //    var employees = context.Employees.Where(s => s.Id == id).FirstOrDefault();
        //    return employees;
        //}

        //int IEmployeeReposatory.Update(Employee employee)
        //{
        //    context.Update(employee);
        //    return context.SaveChanges();
        //}
    }
}
