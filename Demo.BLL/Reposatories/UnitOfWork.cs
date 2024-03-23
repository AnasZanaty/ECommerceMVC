using Demo.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Reposatories
{
    public class UnitOfWork : IUnitOfWork
    {
      
        public IEmployeeReposatory EmployeeReposatory { get; set; }
        public IDepartmentReposatory DepartmentReposatory { get; set; }

        public UnitOfWork(IEmployeeReposatory employeeReposatory , IDepartmentReposatory departmentReposatory)
        {
            EmployeeReposatory = employeeReposatory;
            DepartmentReposatory = departmentReposatory;
        }
    
    }
}
