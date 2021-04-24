using EmployeeManager.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.API.Repositories
{
    // Naming convention, I for interface
    public interface IEmployeeRepository
    {
        List<Employee> SelectAll();
        Employee SelectById(int id);
        void Insert(Employee emp);
        void Update(Employee emp);
        void Delete(int id);
    }
}
