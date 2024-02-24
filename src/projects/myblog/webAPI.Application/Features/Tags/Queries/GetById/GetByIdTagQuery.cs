using Application.Features.Tags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Tags.Queries.GetById;

public class GetByIdTagQuery : IRequest<CustomResponseDto<GetByIdTagResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdTagQueryHandler : IRequestHandler<GetByIdTagQuery, CustomResponseDto<GetByIdTagResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;
        private readonly TagBusinessRules _tagBusinessRules;

        public GetByIdTagQueryHandler(IMapper mapper, ITagRepository tagRepository, TagBusinessRules tagBusinessRules)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
            _tagBusinessRules = tagBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdTagResponse>> Handle(GetByIdTagQuery request, CancellationToken cancellationToken)
        {
            Tag? tag = await _tagRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _tagBusinessRules.TagShouldExistWhenSelected(tag);

            GetByIdTagResponse response = _mapper.Map<GetByIdTagResponse>(tag);

          return CustomResponseDto<GetByIdTagResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}