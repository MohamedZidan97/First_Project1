using TempleteD.Business_Layer.Helper;
using TempleteD.Business_Layer.Interfaces;
using TempleteD.Data_Access_Layer;
using TempleteD.Data_Access_Layer.Entites;
using TempleteD.Models;

namespace TempleteD.Business_Layer.Repositories
{
    public class StudentRep : IStudent
    {
        private readonly ApplicationDbContext db;

        public StudentRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IQueryable<StudentVM> Get()
        {
            var data = db.students.Select(e => new StudentVM { Cv = e.Cv, Id = e.Id });
            return data;

        }
        public void Add(StudentVM Stu)
        {
            Student st = new Student();
            st.Id = Stu.Id;
            st.Cv = UploadFiles.FunUploadFiles(Stu.CvUrl, "Decoments/");
            db.students.Add(st);
            db.SaveChanges();

        }
        public void Delete(int Id)
        {
            var DelObj = db.students.Find(Id);

            db.students.Remove(DelObj);
            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/Files/Decoments/" + DelObj.Cv))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/Files/Decoments/" + DelObj.Cv);
            }
            db.SaveChanges();
        }
    }
}
