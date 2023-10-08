namespace TempleteD.Data_Access_Layer.Entites
{
    public class Dep
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public int NumberOfEmployees { get; set; }
        public string ManagerName { get; set; }

        public ICollection<Emp> Employees { get; set; }
    }
}
