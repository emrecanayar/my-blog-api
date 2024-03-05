using Application.Features.Footers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;

namespace Application.Features.Footers.Queries.GetById;

public class GetByIdFooterQuery : IRequest<CustomResponseDto<GetByIdFooterResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdFooterQueryHandler : IRequestHandler<GetByIdFooterQuery, CustomResponseDto<GetByIdFooterResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IFooterRepository _footerRepository;
        private readonly FooterBusinessRules _footerBusinessRules;

        public GetByIdFooterQueryHandler(IMapper mapper, IFooterRepository footerRepository, FooterBusinessRules footerBusinessRules)
        {
            _mapper = mapper;
            _footerRepository = footerRepository;
            _footerBusinessRules = footerBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdFooterResponse>> Handle(GetByIdFooterQuery request, CancellationToken cancellationToken)
        {
            Footer? footer = await _footerRepository.GetAsync(predicate: f => f.Id == request.Id, cancellationToken: cancellationToken);
            await _footerBusinessRules.FooterShouldExistWhenSelected(footer);

            GetByIdFooterResponse response = _mapper.Map<GetByIdFooterResponse>(footer);

            return CustomResponseDto<GetByIdFooterResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}