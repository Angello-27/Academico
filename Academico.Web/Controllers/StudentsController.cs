namespace Academico.Web.Controllers
{
    using Data.Entities;
    using Data.Repository;
    using Hepers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository repository;
        private readonly IUserHelper userHelper;

        public StudentsController(IStudentRepository repository, IUserHelper userHelper)
        {
            this.repository = repository;
            this.userHelper = userHelper;
        }

        // GET: Students
        public IActionResult Index()
        {
            return View(this.repository.GetAll().OrderBy(s => s.LastName));
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await this.repository.GetByIdAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;
                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Students",
                        file);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }
                    path = $"~/images/Students/{file}";
                }
                var student = this.ToStudent(view, path);
                //TODO: Change for the logged user
                student.User = await this.userHelper.GetUserByEmailAsync("miguel.k2705@gmail.com");
                await this.repository.CreatedAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await this.repository.GetByIdAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            var view = this.ToStudentViewModel(student);
            return View(view);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentViewModel view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImageUrl;
                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";

                        path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot\\images\\Students",
                            file);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }
                        path = $"~/images/Students/{file}";
                    }
                    var student = this.ToStudent(view, path);
                    //TODO: Change for the logged user
                    student.User = await this.userHelper.GetUserByEmailAsync("miguel.k2705@gmail.com");
                    await this.repository.UpdateAsync(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.repository.ExistAsync(view.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await this.repository.GetByIdAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await this.repository.GetByIdAsync(id);
            await this.repository.DeleteAsync(student);
            return RedirectToAction(nameof(Index));
        }

        private Student ToStudent(StudentViewModel view, string path)
        {
            return new Student
            {
                Id = view.Id,
                Name = view.Name,
                LastName = view.LastName,
                ImageUrl = path,
                IsAvailable = view.IsAvailable,
                User = view.User
            };
        }

        private StudentViewModel ToStudentViewModel(Student student)
        {
            return new StudentViewModel
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                ImageUrl = student.ImageUrl,
                IsAvailable = student.IsAvailable,
                User = student.User
            };
        }


    }
}
