using Application.Features.Comments.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace webAPI.Application.Features.Comments.Commands.CreateReply
{
    public class CreateReplyCommentCommand : IRequest<CustomResponseDto<CreatedReplyCommentResponse>>, ISecuredRequest
    {
        public string Content { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public Guid ArticleId { get; set; }
        public Guid ParentCommentId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorEmail { get; set; } = string.Empty;
        public string AuhorWebsite { get; set; } = string.Empty;
        [JsonIgnore]
        public bool SendNewPosts { get; set; } = false;
        [JsonIgnore]
        public bool SendNewComments { get; set; } = false;
        [JsonIgnore]
        public bool RememberMe { get; set; } = false;
        [JsonIgnore]
        public DateTime DatePosted { get; set; } = DateTime.Now;
        public string[] Roles => [CommentsOperationClaims.Write, CommentsOperationClaims.Admin];

        public class CreateReplyCommentCommandHandler : IRequestHandler<CreateReplyCommentCommand, CustomResponseDto<CreatedReplyCommentResponse>>
        {
            private readonly IMapper _mapper;
            private readonly ICommentRepository _commentRepository;

            public CreateReplyCommentCommandHandler(IMapper mapper, ICommentRepository commentRepository)
            {
                _mapper = mapper;
                _commentRepository = commentRepository;
            }

            public async Task<CustomResponseDto<CreatedReplyCommentResponse>> Handle(CreateReplyCommentCommand request, CancellationToken cancellationToken)
            {
                Comment replyComment = _mapper.Map<Comment>(request);
                Comment addedReplyComment = await _commentRepository.AddAsync(replyComment);
                CreatedReplyCommentResponse response = _mapper.Map<CreatedReplyCommentResponse>(addedReplyComment);
                return CustomResponseDto<CreatedReplyCommentResponse>.Success((int)HttpStatusCode.OK, response, true);
            }
        }
    }
}
