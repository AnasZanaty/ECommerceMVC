using Demo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IEmployeeReposatory : IGenericReposatory<Employee>
    {
        IEnumerable<Employee> GetEmployeesByDepartmentName(string name);
        IEnumerable<Employee> search(string name);
        
        //Employee GetEmployeeById(int? id);

        //IEnumerable<Employee> GetAllEmployee();

        //int Add(Employee employee);

        //int Update(Employee employee);

        //int Delete(Employee employee);


    }
}
