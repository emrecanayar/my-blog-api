using Application.Features.Likes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;

namespace Application.Features.Likes.Commands.Create;

public class CreateLikeCommand : IRequest<CustomResponseDto<CreatedLikeResponse>>, ISecuredRequest
{
    [JsonIgnore]
    public Guid UserId { get; set; }
    public Guid CommentId { get; set; }
    public bool IsLiked { get; set; }

    public string[] Roles => [LikesOperationClaims.Admin, LikesOperationClaims.Create];

    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, CustomResponseDto<CreatedLikeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;


        public CreateLikeCommandHandler(IMapper mapper, ILikeRepository likeRepository)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
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