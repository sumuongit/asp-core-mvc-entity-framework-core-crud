using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPCoreMVC_EFCore_CRUD.Models;

namespace ASPCoreMVC_EFCore_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.Include(d=>d.Department).AsNoTracking().ToListAsync());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            var depObj = from e in _context.Employees
                         where e.EmployeeId == id
                         select new { e.Department.DepartmentId };
           
            ViewBag.Departments = new SelectList( _context.Departments, "DepartmentId", "DepartmentName", depObj.Select(x=>x.DepartmentId).FirstOrDefault());

            if (id == 0)
            {
                ViewBag.ActionType = "Add";
                return View(new Employee());
            }
            else
            {
                ViewBag.ActionType = "Edit";
                return View(_context.Employees.Find(id));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.EmployeeId == 0)
                {                    
                    _context.Add(employee);
                    _context.Entry(employee.Department).State = EntityState.Unchanged;
                }
                else
                {                   
                    _context.Update(employee);
                    _context.Entry(employee.Department).State = EntityState.Detached;
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }  

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }       
    }
}
