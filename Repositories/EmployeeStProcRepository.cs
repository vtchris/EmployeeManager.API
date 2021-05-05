using EmployeeManager.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.API.Repositories
{
    public class EmployeeStProcRepository : IEmployeeRepository
    {
        private readonly AppDbContext db = null;

        public EmployeeStProcRepository(AppDbContext db)
        {
            this.db = db;
        }

        public void Delete(int id)
        {
            SqlParameter p = new SqlParameter("@EmployeeID", id);
            db.Employees.FromSqlRaw("EXEC Employee_Delete @EmployeeID", p);

        }

        public void Insert(Employee emp)
        {
            throw new NotImplementedException();
        }

        public List<Employee> SelectAll()
        {
            List<Employee> data = db.Employees.FromSqlRaw("EXEC Employees_SelectAll").ToList();
            return data;
        }

        public Employee SelectById(int id)
        {
            SqlParameter p = new SqlParameter("@EmployeeID", id);
            Employee emp = db.Employees.FromSqlRaw("EXEC Employees_SelectByID @EmployeeID", p).SingleOrDefault();
            return emp;
        }

        public void Update(Employee emp)
        {
            throw new NotImplementedException();
        }
    }
}
