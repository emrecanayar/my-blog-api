using Application.Features.Reports.Commands.Create;
using AutoMapper;
using Core.Domain.Entities;

namespace Application.Features.Reports.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Report, CreateReportCommand>().ReverseMap();
        CreateMap<Report, CreatedReportResponse>().ReverseMap();
    }
}