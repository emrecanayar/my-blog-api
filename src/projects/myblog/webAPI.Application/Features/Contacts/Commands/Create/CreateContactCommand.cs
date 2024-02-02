using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;

namespace Application.Features.Contacts.Commands.Create;

public class CreateContactCommand : IRequest<CustomResponseDto<CreatedContactResponse>>
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;

    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, CustomResponseDto<CreatedContactResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public CreateContactCommandHandler(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<CustomResponseDto<CreatedContactResponse>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            Contact contact = _mapper.Map<Contact>(request);
            await _contactRepository.AddAsync(contact);
            CreatedContactResponse response = _mapper.Map<CreatedContactResponse>(contact);
            return CustomResponseDto<CreatedContactResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}