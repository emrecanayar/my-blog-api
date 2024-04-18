using Application.Features.Comments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;

namespace webAPI.Application.Features.Comments.Commands.Edit
{
    public class EditCommentCommand : IRequest<CustomResponseDto<EditCommentResponse>>
    {
        public Guid Id { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string AuhorWebsite { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; }

        public class EditCommentCommandHandler : IRequestHandler<EditCommentCommand, CustomResponseDto<EditCommentResponse>>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IMapper _mapper;
            private readonly CommentBusinessRules _commentBusinessRules;

            public EditCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper, CommentBusinessRules commentBusinessRules)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
                _commentBusinessRules = commentBusinessRules;
            }

            public async Task<CustomResponseDto<EditCommentResponse>> Handle(EditCommentCommand request, CancellationToken cancellationToken)
            {
                Comment? comment = await _commentRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
                await _commentBusinessRules.CommentShouldExistWhenSelected(comment);
                comment = _mapper.Map(request, comment);

                Comment editedComment = await _commentRepository.UpdateAsync(comment!);
                EditCommentResponse response = _mapper.Map<EditCommentResponse>(editedComment);
                return CustomResponseDto<EditCommentResponse>.Success((int)HttpStatusCode.OK, response, true);
            }
        }
    }
}
