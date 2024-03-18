using Application.Features.Likes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Likes.Commands.Update;

public class UpdateLikeCommand : IRequest<CustomResponseDto<UpdatedLikeResponse>>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CommentId { get; set; }
    public bool IsLiked { get; set; }

    public class UpdateLikeCommandHandler : IRequestHandler<UpdateLikeCommand, CustomResponseDto<UpdatedLikeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;
        private readonly LikeBusinessRules _likeBusinessRules;

        public UpdateLikeCommandHandler(IMapper mapper, ILikeRepository likeRepository,
                                         LikeBusinessRules likeBusinessRules)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
            _likeBusinessRules = likeBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedLikeResponse>> Handle(UpdateLikeCommand request, CancellationToken cancellationToken)
        {
            Like? like = await _likeRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _likeBusinessRules.LikeShouldExistWhenSelected(like);
            like = _mapper.Map(request, like);

            await _likeRepository.UpdateAsync(like!);

            UpdatedLikeResponse response = _mapper.Map<UpdatedLikeResponse>(like);

          return CustomResponseDto<UpdatedLikeResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}