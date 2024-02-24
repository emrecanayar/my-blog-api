using Application.Features.Tags.Constants;
using Application.Features.Tags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Tags.Commands.Delete;

public class DeleteTagCommand : IRequest<CustomResponseDto<DeletedTagResponse>>
{
    public Guid Id { get; set; }

    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, CustomResponseDto<DeletedTagResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;
        private readonly TagBusinessRules _tagBusinessRules;

        public DeleteTagCommandHandler(IMapper mapper, ITagRepository tagRepository,
                                         TagBusinessRules tagBusinessRules)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
            _tagBusinessRules = tagBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedTagResponse>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            Tag? tag = await _tagRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _tagBusinessRules.TagShouldExistWhenSelected(tag);

            await _tagRepository.DeleteAsync(tag!);

            DeletedTagResponse response = _mapper.Map<DeletedTagResponse>(tag);

             return CustomResponseDto<DeletedTagResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}