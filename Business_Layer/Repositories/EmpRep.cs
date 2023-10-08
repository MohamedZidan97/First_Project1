using Microsoft.EntityFrameworkCore;
using TempleteD.Business_Layer.Interfaces;
using TempleteD.Data_Access_Layer.Entites;
using TempleteD.Data_Access_Layer;
using TempleteD.Models;
using AutoMapper;

namespace TempleteD.Business_Layer.Repositories
{
    public class EmpRep : IEmpRep
    {
        private readonly ApplicationDbContext db;/*=new ApplicationDbContext();*/
        private readonly IMapper mapper;
        public EmpRep(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public IQueryable<EmpVM> Get()
        {


            var data = db.employees.Select(e => new EmpVM
            {
                Id = e.Id,
                Name = e.Name,
                Salary = e.Salary,
                Address = e.Address,
                Note = e.Note,
                IsActive = e.IsActive,
                DepartmentId = e.Department.Name,
                HireDate = e.HireDate,
                Email = e.Email,
                BranchId = e.Branch.Name,
                PhotoName=e.PhotoName,
                CVName=e.CVName
                
                

            }) ;

            return data;
        }

        public void Add(EmpVM _emp)
        {
            //Emp emp = new Emp();
            //emp.Name = _emp.Name;
            //emp.Salary = _emp.Salary;
            //emp.Department = _emp.Department;

            // Mapper
            var emp = mapper.Map<Emp>(_emp);

            db.Add(emp);
            db.SaveChanges();
        }

        public EmpVM CheckId(int id)
        {
            var data = db.employees.Where(e => e.Id == id).Select(e => new EmpVM
            {
                Id = e.Id,
                Name = e.Name,
                Salary = e.Salary,
                Email = e.Email,
                IsActive = e.IsActive,
                Address = e.Address,
                HireDate = e.HireDate,
                Note = e.Note,
                DepartmentId = e.Department.Name,
                BranchId = e.Branch.Name,
                PhotoName = e.PhotoName,
                CVName = e.CVName

            }).FirstOrDefault();


            return data;
        }
        public void Edit(EmpVM emp)
        {
            //var d = db.employees.Find(emp.Id);
            //d.Salary = emp.Salary;
            //d.Name = emp.Name;
            //d.Address = emp.Address;
            //d.HireDate = emp.HireDate;
            //d.Email = emp.Email;
            //d.IsActive = emp.IsActive;
            //d.DepartmentId = emp.FK_DepartmentId;
            //d.Note = emp.Note;
            //d.BranchId = emp.BranchId;



            var data = mapper.Map<Emp>(emp);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();


        }

        public void Delete(int id)
        {
            //db.employees.FromSqlRaw("SPEmoDelete" ,id);

            var DelObj = db.employees.Find(id);
            db.employees.Remove(DelObj);
            db.SaveChanges();
        }
    }
}
