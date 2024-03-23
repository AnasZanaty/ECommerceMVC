using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{

    //for injections in controllers
    public  interface IUnitOfWork
    {
        public IEmployeeReposatory EmployeeReposatory { get; set; }

        public IDepartmentReposatory DepartmentReposatory { get; set; }


    }
}
