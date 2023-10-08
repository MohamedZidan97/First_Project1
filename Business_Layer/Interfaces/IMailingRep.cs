namespace TempleteD.Business_Layer.Interfaces
{
    public interface IMailingRep
    {
       Task SendingMail(string mailTo, string subject, string body, IList<IFormFile> attechments = null);
    }
}
