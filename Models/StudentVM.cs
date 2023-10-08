namespace TempleteD.Models
{
    public class StudentVM
    {
        public int Id { get; set; }
        public IFormFile CvUrl { get; set; }
        public string Cv { get; set; }
    }
}
