using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TempleteD.Business_Layer.Repositories;
using TempleteD.Data_Access_Layer.Entites;
using TempleteD.Models;

namespace TempleteD.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepRep Rep;
        public DepartmentController(DepRep rep)
        {
            this.Rep = rep;
        }

        public IActionResult Index()
        {

            var Data = Rep.Get();

            return View(Data);
        }

        // Get Action 

        public IActionResult Create()
        {

            return View();
        }

        // OverLoad 
        // post Or Set Action

        [HttpPost]
        public IActionResult Create(DepVM Dep)
        { 
            try
            {
                if (ModelState.IsValid)
                {
                    Rep.Add(Dep);

                    return RedirectToAction("Index", "Department");
                }
                return View(Dep);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin page";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(Dep);
            }

        }
        public IActionResult Edit(int id)
        {
            var data = Rep.DepartmentMVGetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(DepVM Dep)
        {
            if (ModelState.IsValid)
            {
                Rep.Edit(Dep);
                return RedirectToAction("Index", "Department");
            }

            return View(Dep);
        }
        public IActionResult Delete(int id)
        {
            Rep.Delete(id);

            return RedirectToAction("Index", "Department");
        }
    }
}
