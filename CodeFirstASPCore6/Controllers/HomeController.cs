using CodeFirstASPCore6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CodeFirstASPCore6.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext studentDB;

        public HomeController(StudentDbContext studentDB) 
        {
            this.studentDB = studentDB;
        }
       
        public async Task<IActionResult> Index()
        {
            var stdData = await studentDB.Students.ToListAsync();
            return View(stdData);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await studentDB.Students.AddAsync(std);
                await studentDB.SaveChangesAsync();
                TempData["insert_success"] = "Inserted Successfully";
                return RedirectToAction("Index", "Home");

            }
            return View(std);
        }
        public async Task<IActionResult>Details(int id)
        {
            var stdData = await studentDB.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(stdData);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var stdData = await studentDB.Students.FindAsync(id);
            return View(stdData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Student std)
        {
            if(id != std.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                studentDB.Students.Update(std);
                await studentDB.SaveChangesAsync();
                TempData["Update_success"] = "Updated....";
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var stdData = await studentDB.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(stdData);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var stdDate = await studentDB.Students.FindAsync(id);
            if (stdDate != null)
            {
                studentDB.Students.Remove(stdDate);
            }
            await studentDB.SaveChangesAsync();
            TempData["delete_success"] = "Deleted...";
            return RedirectToAction("Index", "Home");
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

// this is code first project

