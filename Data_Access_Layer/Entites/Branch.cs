namespace TempleteD.Data_Access_Layer.Entites
{
    public class Branch
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public virtual ICollection<Emp> Employees { get; set; }
    }
}
