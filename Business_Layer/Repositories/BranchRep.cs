using TempleteD.Data_Access_Layer;
using TempleteD.Models;

namespace TempleteD.Business_Layer.Repositories
{
    public class BranchRep
    {
        private readonly ApplicationDbContext db;

        public BranchRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IQueryable<BranchVM> Get()
        {
            var Data = db.branches.Select(e => new BranchVM {Id=e.Id, Name = e.Name , CountryId=e.CountryId });

            return Data;

        }
        public BranchVM CheckId(int id)
        {
            var Data = db.branches.Where(e => e.Id == id).Select(e => new BranchVM { Id = e.Id, Name = e.Name, CountryId = e.CountryId }).FirstOrDefault();

            return Data;

        }
    }
}
