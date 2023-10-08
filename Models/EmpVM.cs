namespace TempleteD.Models
{
    public class EmpVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public string PhotoName { get; set; }
        public IFormFile CVUrl { get; set; }
        public string CVName { get; set; }
        public DateTime HireDate { get; set; }
        public string DepartmentId { get; set; }
       // public int DepartmentId { get; set; }
        public string BranchId { get; set; }
      


    }
}
