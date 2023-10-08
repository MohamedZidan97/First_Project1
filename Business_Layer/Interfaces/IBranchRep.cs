using TempleteD.Models;

namespace TempleteD.Business_Layer.Interfaces
{
    public interface IBranchRep
    {
        public IQueryable<BranchVM> Get();
        public BranchVM CheckId(int id);
    }
}
