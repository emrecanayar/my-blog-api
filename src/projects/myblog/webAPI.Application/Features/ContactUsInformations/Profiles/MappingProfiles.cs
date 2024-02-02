using Application.Features.ContactUsInformations.Queries.GetById;
using Application.Features.ContactUsInformations.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ContactUsInformations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ContactUsInformation, GetByIdContactUsInformationResponse>().ReverseMap();
        CreateMap<ContactUsInformation, GetListContactUsInformationListItemDto>().ReverseMap();
        CreateMap<IPaginate<ContactUsInformation>, GetListResponse<GetListContactUsInformationListItemDto>>().ReverseMap();
    }
}