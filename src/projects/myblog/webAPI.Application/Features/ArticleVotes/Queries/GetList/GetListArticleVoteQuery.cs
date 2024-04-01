using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ArticleVotes.Queries.GetList;

public class GetListArticleVoteQuery : IRequest<CustomResponseDto<GetListResponse<GetListArticleVoteListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListArticleVoteQueryHandler : IRequestHandler<GetListArticleVoteQuery, CustomResponseDto<GetListResponse<GetListArticleVoteListItemDto>>>
    {
        private readonly IArticleVoteRepository _articleVoteRepository;
        private readonly IMapper _mapper;

        public GetListArticleVoteQueryHandler(IArticleVoteRepository articleVoteRepository, IMapper mapper)
        {
            _articleVoteRepository = articleVoteRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListArticleVoteListItemDto>>> Handle(GetListArticleVoteQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ArticleVote> articleVotes = await _articleVoteRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListArticleVoteListItemDto> response = _mapper.Map<GetListResponse<GetListArticleVoteListItemDto>>(articleVotes);
             return CustomResponseDto<GetListResponse<GetListArticleVoteListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}