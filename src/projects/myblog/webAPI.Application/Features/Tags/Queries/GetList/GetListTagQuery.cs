using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Tags.Queries.GetList;

public class GetListTagQuery : IRequest<CustomResponseDto<GetListResponse<GetListTagListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListTagQueryHandler : IRequestHandler<GetListTagQuery, CustomResponseDto<GetListResponse<GetListTagListItemDto>>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public GetListTagQueryHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListTagListItemDto>>> Handle(GetListTagQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Tag> tags = await _tagRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTagListItemDto> response = _mapper.Map<GetListResponse<GetListTagListItemDto>>(tags);
             return CustomResponseDto<GetListResponse<GetListTagListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}