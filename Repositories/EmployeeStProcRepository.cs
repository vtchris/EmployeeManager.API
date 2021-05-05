using EmployeeManager.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
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
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@FirstName", emp.FirstName);
            p[1] = new SqlParameter("@LastName", emp.LastName);
            p[2] = new SqlParameter("@Title", emp.Title);
            p[3] = new SqlParameter("@BirthDate", emp.BirthDate);
            p[4] = new SqlParameter("@HireDate", emp.HireDate);
            p[5] = new SqlParameter("@Country", emp.Country);
            p[6] = new SqlParameter("@Notes", emp.Notes ?? SqlString.Null);
            p[7] = new SqlParameter("@EmployeeID", SqlDbType.Int);
            p[7].Direction = ParameterDirection.Output;

            db.Database.ExecuteSqlRaw("EXEC Employees_Insert @FirstName, @LastName, @Title, " +
                "@BirthDate, @HireDate, @Country, @Notes, @EmployeeID OUT", p);
        }

        public List<Employee> SelectAll()
        {
            List<Employee> data = db.Employees.FromSqlRaw("EXEC Employees_SelectAll").ToList();
            return data;
        }

        public Employee SelectById(int id)
        {
            SqlParameter p = new SqlParameter("@EmployeeID", id);
            Employee emp = db.Employees.FromSqlRaw("EXEC Employees_SelectByID @EmployeeID", p).ToList().SingleOrDefault();
            return emp;
        }

        public void Update(Employee emp)
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@EmployeeID", emp.EmployeeID);
            p[1] = new SqlParameter("@FirstName", emp.FirstName);
            p[2] = new SqlParameter("@LastName", emp.LastName);
            p[3] = new SqlParameter("@Title", emp.Title);
            p[4] = new SqlParameter("@BirthDate", emp.BirthDate);
            p[5] = new SqlParameter("@HireDate", emp.HireDate);
            p[6] = new SqlParameter("@Country", emp.Country);
            p[7] = new SqlParameter("@Notes", emp.Notes ?? SqlString.Null);

            db.Database.ExecuteSqlRaw("EXEC Employees_Update @EmployeeID, @FirstName, @LastName, @Title, " +
                "@BirthDate, @HireDate, @Country, @Notes", p);
        }
    }
}
