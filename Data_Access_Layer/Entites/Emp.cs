using AutoMapper.Configuration.Conventions;

namespace TempleteD.Data_Access_Layer.Entites
{
    public class Emp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string PhotoName { get; set; }
        public string CVName { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
        public Dep Department { get; set; } 
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

      
    }
}
