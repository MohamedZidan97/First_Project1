using Microsoft.AspNetCore.Mvc;
using TempleteD.Business_Layer.Helper;
using TempleteD.Business_Layer.Repositories;
using TempleteD.Data_Access_Layer.Entites;
using TempleteD.Models;

namespace TempleteD.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRep student;

        public StudentController(StudentRep student) {
            this.student = student;
        }
        public IActionResult Index()
        {
            var data = student.Get();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentVM St)
        {
            student.Add(St);

            return View(St);
        }

        public IActionResult Delete(int Id)
        {
            student.Delete(Id);

            return RedirectToAction("Index", "Student");

        }
    }
}
