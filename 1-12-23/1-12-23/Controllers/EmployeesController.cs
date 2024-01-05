using _1_12_23.Data;
using _1_12_23.Models;
using _1_12_23.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _1_12_23.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDemoDBContext mvcDemoDBContext;

        public EmployeesController(MVCDemoDBContext mvcDemoDBContext)
        {
            this.mvcDemoDBContext=mvcDemoDBContext;     
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await mvcDemoDBContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest) 
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Department = addEmployeeRequest.Department,
                PhoneNo = addEmployeeRequest.PhoneNo,
            };
            await mvcDemoDBContext.Employees.AddAsync(employee);
            await mvcDemoDBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id) 
        {
            var employee =await mvcDemoDBContext.Employees.FirstOrDefaultAsync(x => x.Id == id); 
            if (employee != null)
            {
                var viewmodel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Department = employee.Department,
                    PhoneNo = employee.PhoneNo,
                };
                return await Task.Run(()=>View("View",viewmodel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model)
        {
            var employee = await mvcDemoDBContext.Employees.FindAsync(model.Id);
            if (employee != null)
            {
                    employee.Name = model.Name;
                    employee.Email= model.Email;
                    employee.Department = model.Department;
                    employee.PhoneNo = model.PhoneNo;

                await mvcDemoDBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var employee = await mvcDemoDBContext.Employees.FindAsync(model.Id);

            if (employee!=null)
            {
                mvcDemoDBContext.Employees.Remove(employee);
                await mvcDemoDBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
