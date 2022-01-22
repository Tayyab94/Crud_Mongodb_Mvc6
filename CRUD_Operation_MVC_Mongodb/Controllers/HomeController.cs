using CRUD_Operation_MVC_Mongodb.Models;
using CRUD_Operation_MVC_Mongodb.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD_Operation_MVC_Mongodb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepositroy employeeRepositroy;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepositroy employeeRepositroy)
        {
            _logger = logger;
            this.employeeRepositroy = employeeRepositroy;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(EmployeeDetail employee)
        {
            var result= await employeeRepositroy.AddEmployee(employee);
            if (result)
                return RedirectToAction("EmployeeList", "Home");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult>EmployeeList()
        {
            return  View(await employeeRepositroy.GetAllEmployees());
        }
        public async Task<IActionResult>DeleteEmployee(string id)
        {
            var restult = await employeeRepositroy.DeleteEmployeeId(id);

            if (restult)
            {
                return RedirectToAction("EmployeeList", "Home");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(string id)
        {
            var restult = await employeeRepositroy.GetEmployeeById(id);

            return View(restult);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeDetail employee)
        {
            //var restult = await employeeRepositroy.GetEmployeeById(id);

            //return View(restult);
            var result= await employeeRepositroy.UpdateEmployee(employee);

            if (result)
            {
                return RedirectToAction("EmployeeList", "Home");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}