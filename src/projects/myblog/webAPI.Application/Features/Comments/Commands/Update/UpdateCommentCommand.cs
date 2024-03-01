using Application.Features.Comments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Commands.Update;

public class UpdateCommentCommand : IRequest<CustomResponseDto<UpdatedCommentResponse>>
{
    public Guid Id { get; set; }
    public string AuthorName { get; set; }
    public string AuthorEmail { get; set; }
    public string AuhorWebsite { get; set; }
    public string Content { get; set; }
    public DateTime DatePosted { get; set; }
    public bool SendNewPosts { get; set; }
    public bool SendNewComments { get; set; }
    public bool RememberMe { get; set; }
    public Guid ArticleId { get; set; }
    public Guid UserId { get; set; }

    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, CustomResponseDto<UpdatedCommentResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        private readonly CommentBusinessRules _commentBusinessRules;

        public UpdateCommentCommandHandler(IMapper mapper, ICommentRepository commentRepository,
                                         CommentBusinessRules commentBusinessRules)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
            _commentBusinessRules = commentBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCommentResponse>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            Comment? comment = await _commentRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _commentBusinessRules.CommentShouldExistWhenSelected(comment);
            comment = _mapper.Map(request, comment);

            await _commentRepository.UpdateAsync(comment!);

            UpdatedCommentResponse response = _mapper.Map<UpdatedCommentResponse>(comment);

          return CustomResponseDto<UpdatedCommentResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}