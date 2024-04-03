using Application.Features.ArticleReports.Commands.Create;
using AutoMapper;
using Core.Domain.Entities;

namespace Application.Features.ArticleReports.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ArticleReport, CreateArticleReportCommand>().ReverseMap();
        CreateMap<ArticleReport, CreatedArticleReportResponse>().ReverseMap();
    }
}