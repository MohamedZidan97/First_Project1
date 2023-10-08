namespace TempleteD.Business_Layer.Helper
{
    public class UploadFiles
    {

        public static string FunUploadFiles(IFormFile St, string FolderPath)
        {
            string MainPath = Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderPath;

            // photo name
            string FileName = Guid.NewGuid() + Path.GetFileName(St.FileName);

            // full Path
            string FullPath = Path.Combine(MainPath, FileName);

            // Save file as Stream
            using (var Stream = new FileStream(FullPath, FileMode.Create))
            {
                St.CopyTo(Stream);
            }

            return FileName;
        }
    }
}
