using TempleteD.Business_Layer.Interfaces;
using TempleteD.Data_Access_Layer;
using TempleteD.Data_Access_Layer.Entites;
using TempleteD.Models;

namespace TempleteD.Business_Layer.Repositories
{
    public class DepRep : IDepRep
    {
        private readonly ApplicationDbContext Db;

        public DepRep(ApplicationDbContext db)
        {
            this.Db = db;
        }

        public IQueryable<DepVM> Get()
        {

            var Data = Db.departments.Select(e => new DepVM
            {
                Id = e.Id,
                Name = e.Name,
                NumberOfEmployees = e.NumberOfEmployees,
                ManagerName = e.ManagerName
            });

            //var SData = Data.OrderBy(e => e.NumberOfEmployees);

            return Data;
        }

        public void Add(DepVM dep)
        {
            var d = new Dep();


            d.ManagerName = dep.ManagerName;
            d.Name = dep.Name;
            d.NumberOfEmployees = dep.NumberOfEmployees;

            Db.departments.Add(d);
            Db.SaveChanges();

        }

        public DepVM DepartmentMVGetById(int id)
        {

            DepVM dep = Db.departments.Where(e => e.Id == id).Select(e => new DepVM
            {
                Id = e.Id,
                Name = e.Name,
                ManagerName = e.ManagerName,
                NumberOfEmployees = e.NumberOfEmployees,
            }).FirstOrDefault();

            return dep;

        }

        public void Edit(DepVM dep)
        {
           // Dep d = new Dep();
           var d = Db.departments.Find(dep.Id);
            d.ManagerName = dep.ManagerName;
            d.NumberOfEmployees = dep.NumberOfEmployees;
            d.Name = dep.Name;

            Db.SaveChanges();

        }
        public void Delete(int id)
        {
            var del = Db.departments.Find(id);
            Db.departments.Remove(del);
            Db.SaveChanges();
        }

    }
}
