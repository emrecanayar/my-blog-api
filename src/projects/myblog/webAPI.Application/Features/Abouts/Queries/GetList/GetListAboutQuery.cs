using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using System.Net;

namespace Application.Features.Abouts.Queries.GetList;

public class GetListAboutQuery : IRequest<CustomResponseDto<GetListResponse<GetListAboutListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public GetListAboutQuery()
    {
        PageRequest = default!;
    }

    public class GetListAboutQueryHandler : IRequestHandler<GetListAboutQuery, CustomResponseDto<GetListResponse<GetListAboutListItemDto>>>
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IMapper _mapper;

        public GetListAboutQueryHandler(IAboutRepository aboutRepository, IMapper mapper)
        {
            _aboutRepository = aboutRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListAboutListItemDto>>> Handle(GetListAboutQuery request, CancellationToken cancellationToken)
        {
            IPaginate<About> abouts = await _aboutRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAboutListItemDto> response = _mapper.Map<GetListResponse<GetListAboutListItemDto>>(abouts);
            return CustomResponseDto<GetListResponse<GetListAboutListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}