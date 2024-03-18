using Application.Features.Likes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;

namespace Application.Features.Likes.Queries.GetById;

public class GetByIdLikeQuery : IRequest<CustomResponseDto<GetByIdLikeResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdLikeQueryHandler : IRequestHandler<GetByIdLikeQuery, CustomResponseDto<GetByIdLikeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;
        private readonly LikeBusinessRules _likeBusinessRules;

        public GetByIdLikeQueryHandler(IMapper mapper, ILikeRepository likeRepository, LikeBusinessRules likeBusinessRules)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
            _likeBusinessRules = likeBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdLikeResponse>> Handle(GetByIdLikeQuery request, CancellationToken cancellationToken)
        {
            Like? like = await _likeRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _likeBusinessRules.LikeShouldExistWhenSelected(like);

            GetByIdLikeResponse response = _mapper.Map<GetByIdLikeResponse>(like);

            return CustomResponseDto<GetByIdLikeResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}