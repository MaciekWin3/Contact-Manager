using AutoMapper;
using Core.Data.Dtos;
using Core.Models;

namespace Core.Data.Mappings
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateEntityToDTOMappings();
            CreateDTOToEntityMappings();
        }

        private void CreateEntityToDTOMappings()
        {
            CreateMap<Contact, ContactDto>();
        }
        private void CreateDTOToEntityMappings()
        {
            CreateMap<ContactDto, Contact>();
            CreateMap<ContactForCreationDto, Contact>();
            CreateMap<ContactForUpdateDto, Contact>();
        }
    }
}
