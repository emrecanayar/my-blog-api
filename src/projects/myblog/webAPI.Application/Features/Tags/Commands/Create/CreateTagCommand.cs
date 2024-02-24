using Application.Features.Tags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Tags.Commands.Create;

public class CreateTagCommand : IRequest<CustomResponseDto<CreatedTagResponse>>
{
    public string Name { get; set; }
    public Guid ArticleId { get; set; }

    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, CustomResponseDto<CreatedTagResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;
        private readonly TagBusinessRules _tagBusinessRules;

        public CreateTagCommandHandler(IMapper mapper, ITagRepository tagRepository,
                                         TagBusinessRules tagBusinessRules)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
            _tagBusinessRules = tagBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedTagResponse>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            Tag tag = _mapper.Map<Tag>(request);

            await _tagRepository.AddAsync(tag);

            CreatedTagResponse response = _mapper.Map<CreatedTagResponse>(tag);
         return CustomResponseDto<CreatedTagResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}