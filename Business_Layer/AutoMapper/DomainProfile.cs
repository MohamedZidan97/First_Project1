using AutoMapper;
using TempleteD.Data_Access_Layer.Entites;
using TempleteD.Models;

namespace TempleteD.Business_Layer.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Emp, EmpVM>();
            CreateMap<EmpVM, Emp>();
        }
    }
}
