using EmployeeManager.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.API.Repositories
{
    public class EmployeeSqlRepository : IEmployeeRepository
    {
        private readonly AppDbContext db = null;

        public EmployeeSqlRepository(AppDbContext db)
        {
            this.db = db;
        }
        public void Delete(Employee emp)
        {
            
        }

        public void Insert(Employee emp)
        {
            throw new NotImplementedException();
        }

        public List<Employee> SelectAll()
        {
            List<Employee> data = db.Employees.FromSqlRaw("SELECT EmployeeId, FirstName, LastName, " +
                "Title, BirthDate, HireDate, Country, Notes FROM Employees ORDER BY EmployeeId ASC").ToList();

            return data;
        }

        public Employee SelectById(int id)
        {
            Employee emp = db.Employees.FromSqlRaw("SELECT EmployeeId, FirstName, LastName, " +
                "Title, BirthDate, HireDate, Country, Notes FROM Employees WHERE EmployeeId = {id}", id).SingleOrDefault();

            return emp;
         }

        public void Update(Employee emp)
        {
            throw new NotImplementedException();
        }
    }
}
