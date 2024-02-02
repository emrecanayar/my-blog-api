using Application.Features.Contacts.Commands.Create;
using AutoMapper;
using Core.Domain.Entities;

namespace Application.Features.Contacts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Contact, CreateContactCommand>().ReverseMap();
        CreateMap<Contact, CreatedContactResponse>().ReverseMap();
    }
}