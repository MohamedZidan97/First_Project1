namespace TempleteD.Data_Access_Layer.Entites
{
    public class Country
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }


        
    }
}
