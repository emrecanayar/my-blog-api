using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using System.Net;

namespace Application.Features.Footers.Queries.GetList;

public class GetListFooterQuery : IRequest<CustomResponseDto<GetListResponse<GetListFooterListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public GetListFooterQuery()
    {
        PageRequest = default!;
    }

    public class GetListFooterQueryHandler : IRequestHandler<GetListFooterQuery, CustomResponseDto<GetListResponse<GetListFooterListItemDto>>>
    {
        private readonly IFooterRepository _footerRepository;
        private readonly IMapper _mapper;

        public GetListFooterQueryHandler(IFooterRepository footerRepository, IMapper mapper)
        {
            _footerRepository = footerRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListFooterListItemDto>>> Handle(GetListFooterQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Footer> footers = await _footerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFooterListItemDto> response = _mapper.Map<GetListResponse<GetListFooterListItemDto>>(footers);
            return CustomResponseDto<GetListResponse<GetListFooterListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}