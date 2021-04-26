using EmployeeManager.API.Models;
using EmployeeManager.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.API.Controllers
{
    // You could use EmployeesController, but if name changed later its common to just specify controller as 
    // an attribute... this will work for the route 'Employees' 
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository employeeRepository = null;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public List<Employee> Get()
        {
            return employeeRepository.SelectAll();
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return employeeRepository.SelectById(id);
        }

        [HttpPost]
        public void Post([FromBody] Employee emp)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.Insert(emp);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee emp)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.Update(emp);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
            employeeRepository.Delete(id);
            
        }

    }
}
