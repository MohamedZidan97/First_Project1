using TempleteD.Models;

namespace TempleteD.Business_Layer.Interfaces
{
    public interface IEmpRep
    {
        public IQueryable<EmpVM> Get();
        public void Add(EmpVM emp);
        public EmpVM CheckId(int id);
        public void Edit(EmpVM emp);
        public void Delete(int id);
    }
}
