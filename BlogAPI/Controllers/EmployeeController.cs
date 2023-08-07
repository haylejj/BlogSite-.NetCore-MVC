using BlogAPI.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using(var c=new Context())
            {
                var values=c.Employees.ToList();
                return Ok(values);
            }
        }
        [HttpPost]
        public IActionResult EmployeeAdd(Employee p)
        {
            using (var c = new Context())
            {
                c.Add(p);
                c.SaveChanges();
                return Ok();
            }
        }
        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using (var c = new Context())
            {
                var employee = c.Employees.Find(id);
                if (employee == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(employee);
                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using (var c = new Context())
            {
                var employee = c.Employees.Find(id);
                if (employee == null)
                {
                    return NotFound();
                }
                else
                {
                    c.Remove(employee);
                    c.SaveChanges();
                    return Ok(employee);
                }
            }
        }
        [HttpPut]
        public IActionResult EmployeeUpdate(Employee p)
        {
            using (var c = new Context())
            {
                var employee = c.Employees.Find(p.Id);
                if (employee == null)
                {
                    return NotFound();
                }
                else
                {
                    employee.Name=p.Name;
                    c.Update(employee);
                    c.SaveChanges();
                    return Ok(employee);
                }
            }
        }
    }
}
