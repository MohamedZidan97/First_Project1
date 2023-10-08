using TempleteD.Data_Access_Layer.Entites;
using TempleteD.Models;

namespace TempleteD.Business_Layer.Interfaces
{
    public interface IStudent
    {
       IQueryable<StudentVM> Get();
        void Add(StudentVM Stu);
        void Delete(int Id);
    }
}
