using Application.Features.ContactUsInformations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;

namespace Application.Features.ContactUsInformations.Queries.GetById;

public class GetByIdContactUsInformationQuery : IRequest<CustomResponseDto<GetByIdContactUsInformationResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdContactUsInformationQueryHandler : IRequestHandler<GetByIdContactUsInformationQuery, CustomResponseDto<GetByIdContactUsInformationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IContactUsInformationRepository _contactUsInformationRepository;
        private readonly ContactUsInformationBusinessRules _contactUsInformationBusinessRules;

        public GetByIdContactUsInformationQueryHandler(IMapper mapper, IContactUsInformationRepository contactUsInformationRepository, ContactUsInformationBusinessRules contactUsInformationBusinessRules)
        {
            _mapper = mapper;
            _contactUsInformationRepository = contactUsInformationRepository;
            _contactUsInformationBusinessRules = contactUsInformationBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdContactUsInformationResponse>> Handle(GetByIdContactUsInformationQuery request, CancellationToken cancellationToken)
        {
            ContactUsInformation? contactUsInformation = await _contactUsInformationRepository.GetAsync(predicate: cui => cui.Id == request.Id, cancellationToken: cancellationToken);
            await _contactUsInformationBusinessRules.ContactUsInformationShouldExistWhenSelected(contactUsInformation);
            GetByIdContactUsInformationResponse response = _mapper.Map<GetByIdContactUsInformationResponse>(contactUsInformation);
            return CustomResponseDto<GetByIdContactUsInformationResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}