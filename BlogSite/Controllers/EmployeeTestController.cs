using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BlogSite.Controllers
{
    public class EmployeeTestController : Controller
    {
        public async Task<IActionResult>Index()
        {
            var httpClient=new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7192/api/Employee");
            var jsonString=await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<class1>>(jsonString);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content=new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7192/api/Employee", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);

        }
        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var httpClient=new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7192/api/Employee/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<class1>(jsonEmployee);
                return View(values);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7192/api/Employee", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:7192/api/Employee/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
            
        }
    }
    public class class1
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
