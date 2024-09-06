using AutoMapper;
using ContactAppApi.DTOs;
using ContactAppApi.Models;

namespace ContactAppApi.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Contact, ContactDto>();

            CreateMap<AddContactDto, Contact>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());
        }
    }
}
