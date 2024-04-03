using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.ComplexTypes.Enums;
using Core.Domain.Entities;
using MediatR;
using System.Net;

namespace Application.Features.ArticleReports.Commands.Create;

public class CreateArticleReportCommand : IRequest<CustomResponseDto<CreatedArticleReportResponse>>
{
    public string Description { get; set; } = string.Empty;
    public Guid ArticleId { get; set; }
    public ArticleReportType ReportType { get; set; }

    public class CreateArticleReportCommandHandler : IRequestHandler<CreateArticleReportCommand, CustomResponseDto<CreatedArticleReportResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleReportRepository _articleReportRepository;

        public CreateArticleReportCommandHandler(IMapper mapper, IArticleReportRepository articleReportRepository)
        {
            _mapper = mapper;
            _articleReportRepository = articleReportRepository;
        }

        public async Task<CustomResponseDto<CreatedArticleReportResponse>> Handle(CreateArticleReportCommand request, CancellationToken cancellationToken)
        {
            ArticleReport articleReport = _mapper.Map<ArticleReport>(request);
            ArticleReport addedArticleReport = await _articleReportRepository.AddAsync(articleReport);
            CreatedArticleReportResponse response = _mapper.Map<CreatedArticleReportResponse>(addedArticleReport);
            return CustomResponseDto<CreatedArticleReportResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}