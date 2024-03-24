using Application.Services.Repositories;
using Core.Application.ResponseTypes.Concrete;
using MediatR;
using System.Net;

namespace webAPI.Application.Features.Likes.Queries.GetByCommentIdLike
{
    public class GetByCommentIdLikeQuery : IRequest<CustomResponseDto<GetByCommentIdLikeResponse>>
    {
        public Guid CommentId { get; set; }

        public class GetByCommentIdLikeQueryHandler : IRequestHandler<GetByCommentIdLikeQuery, CustomResponseDto<GetByCommentIdLikeResponse>>
        {
            private readonly ILikeRepository _likeRepository;

            public GetByCommentIdLikeQueryHandler(ILikeRepository likeRepository)
            {
                _likeRepository = likeRepository;
            }

            public async Task<CustomResponseDto<GetByCommentIdLikeResponse>> Handle(GetByCommentIdLikeQuery request, CancellationToken cancellationToken)
            {
                int likeCount = await _likeRepository.CountLikeAsync(request.CommentId);
                return CustomResponseDto<GetByCommentIdLikeResponse>.Success((int)HttpStatusCode.OK, new GetByCommentIdLikeResponse { LikeCount = likeCount }, true);

            }
        }
    }
}
