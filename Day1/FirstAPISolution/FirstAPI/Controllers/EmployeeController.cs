using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee{Id=1,Name="Ramu",Age=25,Salary=235454.4f}
        };
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }

        [HttpPost]
        public Employee Post(Employee employee)
        {
            employee.Id = employees[employees.Count - 1].Id + 1;
            employees.Add(employee);
            return employee;
        }
        [HttpPut]
        public Employee Edit(int employee_id, Employee employee)
        {
            int idx = -1;
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == employee_id)
                {
                    idx = i;
                    break;
                }
            }
            if(idx>0)
            {
                employees[idx] = employee;
            }
            return employee;

        }
        [HttpDelete]
        public void Delete(int employee_id)
        {
            int idx = -1;
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == employee_id)
                {
                    idx = i;
                    break;
                }
            }
            if (idx > 0)
            {
                employees.RemoveAt(idx);
            }
                
        }
    }
}
