using Application.Features.Reports.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;

namespace Application.Features.Reports.Commands.Create;

public class CreateReportCommand : IRequest<CustomResponseDto<CreatedReportResponse>>, ISecuredRequest
{
    public string Reason { get; set; } = string.Empty;
    [JsonIgnore]
    public Guid UserId { get; set; }
    public DateTime DateReported { get; set; } = DateTime.Now;
    public Guid CommentId { get; set; }

    public string[] Roles => [ReportsOperationClaims.Write, ReportsOperationClaims.Admin];

    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, CustomResponseDto<CreatedReportResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;

        public CreateReportCommandHandler(IMapper mapper, IReportRepository reportRepository)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
        }

        public async Task<CustomResponseDto<CreatedReportResponse>> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            Report report = _mapper.Map<Report>(request);
            Report addedRepository = await _reportRepository.AddAsync(report);
            CreatedReportResponse response = _mapper.Map<CreatedReportResponse>(addedRepository);
            return CustomResponseDto<CreatedReportResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}