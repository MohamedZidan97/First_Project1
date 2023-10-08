using TempleteD.Business_Layer.Interfaces;
using TempleteD.Data_Access_Layer;
using TempleteD.Models;

namespace TempleteD.Business_Layer.Repositories
{
    public class CountryRep : ICountryRep
    {
        private readonly ApplicationDbContext db;

        public CountryRep (ApplicationDbContext db)
        {
            this.db = db;
        }
        public IQueryable<CountryVM> Get()
        {
            var Data = db.countries.Select(e => new CountryVM {Id=e.Id, Name = e.Name });

            return Data;

        }
        public CountryVM CheckId(int id)
        {
            var Data = db.countries.Where(e => e.Id == id).Select(e=> new CountryVM { Id = e.Id, Name = e.Name}).FirstOrDefault();

            return Data;

        }
    }
}
