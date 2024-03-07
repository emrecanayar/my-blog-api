using Application.Features.UserUploadedFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.UserUploadedFiles.Commands.Update;

public class UpdateUserUploadedFileCommand : IRequest<CustomResponseDto<UpdatedUserUploadedFileResponse>>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; }
    public string NewPath { get; set; }

    public class UpdateUserUploadedFileCommandHandler : IRequestHandler<UpdateUserUploadedFileCommand, CustomResponseDto<UpdatedUserUploadedFileResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserUploadedFileRepository _userUploadedFileRepository;
        private readonly UserUploadedFileBusinessRules _userUploadedFileBusinessRules;

        public UpdateUserUploadedFileCommandHandler(IMapper mapper, IUserUploadedFileRepository userUploadedFileRepository,
                                         UserUploadedFileBusinessRules userUploadedFileBusinessRules)
        {
            _mapper = mapper;
            _userUploadedFileRepository = userUploadedFileRepository;
            _userUploadedFileBusinessRules = userUploadedFileBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedUserUploadedFileResponse>> Handle(UpdateUserUploadedFileCommand request, CancellationToken cancellationToken)
        {
            UserUploadedFile? userUploadedFile = await _userUploadedFileRepository.GetAsync(predicate: uuf => uuf.Id == request.Id, cancellationToken: cancellationToken);
            await _userUploadedFileBusinessRules.UserUploadedFileShouldExistWhenSelected(userUploadedFile);
            userUploadedFile = _mapper.Map(request, userUploadedFile);

            await _userUploadedFileRepository.UpdateAsync(userUploadedFile!);

            UpdatedUserUploadedFileResponse response = _mapper.Map<UpdatedUserUploadedFileResponse>(userUploadedFile);

          return CustomResponseDto<UpdatedUserUploadedFileResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}