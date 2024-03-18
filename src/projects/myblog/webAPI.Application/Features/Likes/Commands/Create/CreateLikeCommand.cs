using Application.Features.Likes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Likes.Commands.Create;

public class CreateLikeCommand : IRequest<CustomResponseDto<CreatedLikeResponse>>
{
    public Guid UserId { get; set; }
    public Guid CommentId { get; set; }
    public bool IsLiked { get; set; }

    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, CustomResponseDto<CreatedLikeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;
        private readonly LikeBusinessRules _likeBusinessRules;

        public CreateLikeCommandHandler(IMapper mapper, ILikeRepository likeRepository,
                                         LikeBusinessRules likeBusinessRules)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
            _likeBusinessRules = likeBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedLikeResponse>> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
        {
            Like like = _mapper.Map<Like>(request);

            await _likeRepository.AddAsync(like);

            CreatedLikeResponse response = _mapper.Map<CreatedLikeResponse>(like);
         return CustomResponseDto<CreatedLikeResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}