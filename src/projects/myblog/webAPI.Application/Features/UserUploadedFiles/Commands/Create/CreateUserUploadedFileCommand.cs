using Application.Features.UserUploadedFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.UserUploadedFiles.Commands.Create;

public class CreateUserUploadedFileCommand : IRequest<CustomResponseDto<CreatedUserUploadedFileResponse>>
{
    public Guid UserId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; }
    public string NewPath { get; set; }

    public class CreateUserUploadedFileCommandHandler : IRequestHandler<CreateUserUploadedFileCommand, CustomResponseDto<CreatedUserUploadedFileResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserUploadedFileRepository _userUploadedFileRepository;
        private readonly UserUploadedFileBusinessRules _userUploadedFileBusinessRules;

        public CreateUserUploadedFileCommandHandler(IMapper mapper, IUserUploadedFileRepository userUploadedFileRepository,
                                         UserUploadedFileBusinessRules userUploadedFileBusinessRules)
        {
            _mapper = mapper;
            _userUploadedFileRepository = userUploadedFileRepository;
            _userUploadedFileBusinessRules = userUploadedFileBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedUserUploadedFileResponse>> Handle(CreateUserUploadedFileCommand request, CancellationToken cancellationToken)
        {
            UserUploadedFile userUploadedFile = _mapper.Map<UserUploadedFile>(request);

            await _userUploadedFileRepository.AddAsync(userUploadedFile);

            CreatedUserUploadedFileResponse response = _mapper.Map<CreatedUserUploadedFileResponse>(userUploadedFile);
         return CustomResponseDto<CreatedUserUploadedFileResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}