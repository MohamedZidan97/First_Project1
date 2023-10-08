using TempleteD.Models;

namespace TempleteD.Business_Layer.Interfaces
{
    public interface ICountryRep
    {
        public IQueryable<CountryVM> Get();
        public CountryVM CheckId(int id);
    }
}
