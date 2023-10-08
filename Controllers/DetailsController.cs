using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using TempleteD.Business_Layer.Repositories;


namespace TempleteD.Controllers
{
    public class DetailsController : Controller
    {
        private readonly CountryRep country;
        private readonly BranchRep branch;
        private readonly DepRep dep;

        public DetailsController(CountryRep country,BranchRep branch,DepRep dep)
        {
            this.country = country;
            this.branch = branch;
            this.dep = dep;
        }
        public IActionResult Index()
        {
            var countries = country.Get();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name");
            return View();
        }
        public IActionResult ShowDepartments()
        {
            var data = dep.Get();
            return View(data);
        }

 

        public JsonResult BranchesInOneCountry(int count)
        {
            var branches = branch.Get().Where(e => e.CountryId == count);
            return Json(branches);
        }
      




        [HttpPost]
        public JsonResult Display()
        {
            var d = "Zidan";
            
            return  Json (d);

        }
    }
}
