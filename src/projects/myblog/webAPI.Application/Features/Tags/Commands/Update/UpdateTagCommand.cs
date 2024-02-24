using Application.Features.Tags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Tags.Commands.Update;

public class UpdateTagCommand : IRequest<CustomResponseDto<UpdatedTagResponse>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ArticleId { get; set; }

    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, CustomResponseDto<UpdatedTagResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;
        private readonly TagBusinessRules _tagBusinessRules;

        public UpdateTagCommandHandler(IMapper mapper, ITagRepository tagRepository,
                                         TagBusinessRules tagBusinessRules)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
            _tagBusinessRules = tagBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedTagResponse>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            Tag? tag = await _tagRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _tagBusinessRules.TagShouldExistWhenSelected(tag);
            tag = _mapper.Map(request, tag);

            await _tagRepository.UpdateAsync(tag!);

            UpdatedTagResponse response = _mapper.Map<UpdatedTagResponse>(tag);

          return CustomResponseDto<UpdatedTagResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}