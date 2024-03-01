using Application.Features.Comments.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.Comments.Rules;

public class CommentBusinessRules : BaseBusinessRules
{
    private readonly ICommentRepository _commentRepository;

    public CommentBusinessRules(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public Task CommentShouldExistWhenSelected(Comment? comment)
    {
        if (comment == null)
            throw new BusinessException(CommentsBusinessMessages.CommentNotExists);
        return Task.CompletedTask;
    }

    public async Task CommentIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Comment? comment = await _commentRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CommentShouldExistWhenSelected(comment);
    }
}