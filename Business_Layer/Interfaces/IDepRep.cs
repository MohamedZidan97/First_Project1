using TempleteD.Data_Access_Layer.Entites;
using TempleteD.Models;

namespace TempleteD.Business_Layer.Interfaces
{
    public interface IDepRep
    {
        IQueryable<DepVM> Get();

        void Add(DepVM department);

        DepVM DepartmentMVGetById(int id);
        void Edit(DepVM department);
        void Delete(int id);
    }
}
