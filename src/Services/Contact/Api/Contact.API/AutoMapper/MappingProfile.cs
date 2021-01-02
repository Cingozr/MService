using AutoMapper;
using Contact.API.Models;
using Contact.Data.Entities;

namespace Contact.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateContactModel, Contacts>().ReverseMap();
            CreateMap<CreateContactInformationModel, ContactInformations>().ReverseMap();
            CreateMap<ContactInformationModel, ContactInformations>().ReverseMap();
            CreateMap<GetAllContactModel, Contacts>().ReverseMap();
            CreateMap<GetAllContactInformation, Contacts>().ReverseMap();
        }
    }
}
