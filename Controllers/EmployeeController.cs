using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using TempleteD.Business_Layer.Repositories;
using TempleteD.Data_Access_Layer;
using TempleteD.Models;
using TempleteD.Resourse;

namespace TempleteD.Controllers
{
    public class EmployeeController : Controller
    {

        //     local       //  Instance
        private readonly EmpRep Rep;
        private readonly CountryRep country;
        private readonly BranchRep branch;
        private readonly DepRep Dep;
        //private readonly IStringLocalizer<LanguegeResource> sharedLocalizer;

        public EmployeeController(EmpRep rep,CountryRep country, BranchRep branch, DepRep dep)
        {
            this.Rep = rep;
            this.country = country;
            this.branch = branch;
            this.Dep = dep;
           // this.sharedLocalizer = SharedLocalizer;
        }
        public IActionResult EmpIndex()
        {
          
            var Data = Rep.Get();

            return View(Data);
        }
        public IActionResult EmpCreate()
        {
            var departments = Dep.Get();
            ViewBag.DepartmentList = new SelectList(departments, "Id", "Name");
            var countries = country.Get();
            ViewBag.CountryList =new SelectList(countries, "Id", "Name");
            var branches = branch.Get();
            ViewBag.BranchList = new SelectList(branches, "Id", "Name");



            return View();
        }

        [HttpPost]
        public IActionResult EmpCreate(EmpVM emp)
        {
            try
            {
                #region Save photo

                // main path
                string MainPath1 = Directory.GetCurrentDirectory() + "/wwwroot/Files/Photos/";

                // photo name
                string PhotoName = Guid.NewGuid() + Path.GetFileName(emp.PhotoUrl.FileName);

                // full Path
                string FullPath1 = Path.Combine(MainPath1 , PhotoName);

                // Save file as Stream
                using (var Stream = new FileStream(FullPath1, FileMode.Create))
                {
                    emp.PhotoUrl.CopyTo(Stream);
                }
                #endregion

                #region Save CV

                // main path
                string MainPath2 = Directory.GetCurrentDirectory() + "/wwwroot/Files/Decoments/";

                // photo name
                string CVName = Guid.NewGuid() + Path.GetFileName(emp.CVUrl.FileName);

                // full Path
                string FullPath2 = Path.Combine(MainPath2, CVName);

                // Save file as Stream
                using (var Stream = new FileStream(FullPath2, FileMode.Create))
                {
                    emp.CVUrl.CopyTo(Stream);
                }
                #endregion

                if (ModelState.IsValid)
                {
                    Rep.Add(emp);
                    return RedirectToAction("EmpIndex", "Employee");
                }

                return View(emp);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin page";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View(emp);
            }

        }

        public IActionResult EmpEdit(int id)
        {
            var data = Rep.CheckId(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult EmpEdit(EmpVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Rep.Edit(emp);
                    return RedirectToAction("EmpIndex", "Employee");
                }

                return View(emp);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin page";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(emp);
            }

        }

        public IActionResult EmpDelete(int id)
        {
            Rep.Delete(id);
            return RedirectToAction("EmpIndex", "Employee");
        }

        //------------------------ajax---------------
       
        public JsonResult AllBrenchinCountry(int cntryid)
        {
            var BranchesInCountry = branch.Get().Where(e => e.CountryId == cntryid);
            return Json(BranchesInCountry);
        }
    }
}
