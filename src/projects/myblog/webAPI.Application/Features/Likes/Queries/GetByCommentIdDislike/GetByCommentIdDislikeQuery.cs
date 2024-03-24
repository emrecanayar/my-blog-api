using Application.Services.Repositories;
using Core.Application.ResponseTypes.Concrete;
using MediatR;
using System.Net;

namespace webAPI.Application.Features.Likes.Queries.GetByCommentIdDislike
{
    public class GetByCommentIdDislikeQuery : IRequest<CustomResponseDto<GetByCommentIdDislikeResponse>>
    {
        public Guid CommentId { get; set; }

        public class GetByCommentIdDislikeQueryHandler : IRequestHandler<GetByCommentIdDislikeQuery, CustomResponseDto<GetByCommentIdDislikeResponse>>
        {
            private readonly ILikeRepository _likeRepository;

            public GetByCommentIdDislikeQueryHandler(ILikeRepository likeRepository)
            {
                _likeRepository = likeRepository;
            }

            public async Task<CustomResponseDto<GetByCommentIdDislikeResponse>> Handle(GetByCommentIdDislikeQuery request, CancellationToken cancellationToken)
            {
                int dislikeCount = await _likeRepository.CountDislikeAsync(request.CommentId);
                return CustomResponseDto<GetByCommentIdDislikeResponse>.Success((int)HttpStatusCode.OK, new GetByCommentIdDislikeResponse { DislikeCount = dislikeCount }, true);
            }
        }
    }
}
