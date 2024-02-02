using Application.Features.Abouts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;

namespace Application.Features.Abouts.Queries.GetById;

public class GetByIdAboutQuery : IRequest<CustomResponseDto<GetByIdAboutResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdAboutQueryHandler : IRequestHandler<GetByIdAboutQuery, CustomResponseDto<GetByIdAboutResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAboutRepository _aboutRepository;
        private readonly AboutBusinessRules _aboutBusinessRules;

        public GetByIdAboutQueryHandler(IMapper mapper, IAboutRepository aboutRepository, AboutBusinessRules aboutBusinessRules)
        {
            _mapper = mapper;
            _aboutRepository = aboutRepository;
            _aboutBusinessRules = aboutBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdAboutResponse>> Handle(GetByIdAboutQuery request, CancellationToken cancellationToken)
        {
            About? about = await _aboutRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _aboutBusinessRules.AboutShouldExistWhenSelected(about);
            GetByIdAboutResponse response = _mapper.Map<GetByIdAboutResponse>(about);
            return CustomResponseDto<GetByIdAboutResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}