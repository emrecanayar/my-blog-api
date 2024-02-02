using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using System.Net;

namespace Application.Features.ContactUsInformations.Queries.GetList;

public class GetListContactUsInformationQuery : IRequest<CustomResponseDto<GetListResponse<GetListContactUsInformationListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public GetListContactUsInformationQuery()
    {
        PageRequest = default!;
    }

    public class GetListContactUsInformationQueryHandler : IRequestHandler<GetListContactUsInformationQuery, CustomResponseDto<GetListResponse<GetListContactUsInformationListItemDto>>>
    {
        private readonly IContactUsInformationRepository _contactUsInformationRepository;
        private readonly IMapper _mapper;

        public GetListContactUsInformationQueryHandler(IContactUsInformationRepository contactUsInformationRepository, IMapper mapper)
        {
            _contactUsInformationRepository = contactUsInformationRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListContactUsInformationListItemDto>>> Handle(GetListContactUsInformationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ContactUsInformation> contactUsInformations = await _contactUsInformationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListContactUsInformationListItemDto> response = _mapper.Map<GetListResponse<GetListContactUsInformationListItemDto>>(contactUsInformations);
            return CustomResponseDto<GetListResponse<GetListContactUsInformationListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}