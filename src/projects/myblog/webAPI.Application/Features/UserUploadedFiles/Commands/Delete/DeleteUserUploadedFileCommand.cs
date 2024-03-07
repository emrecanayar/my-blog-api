using Application.Features.UserUploadedFiles.Constants;
using Application.Features.UserUploadedFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.UserUploadedFiles.Commands.Delete;

public class DeleteUserUploadedFileCommand : IRequest<CustomResponseDto<DeletedUserUploadedFileResponse>>
{
    public Guid Id { get; set; }

    public class DeleteUserUploadedFileCommandHandler : IRequestHandler<DeleteUserUploadedFileCommand, CustomResponseDto<DeletedUserUploadedFileResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserUploadedFileRepository _userUploadedFileRepository;
        private readonly UserUploadedFileBusinessRules _userUploadedFileBusinessRules;

        public DeleteUserUploadedFileCommandHandler(IMapper mapper, IUserUploadedFileRepository userUploadedFileRepository,
                                         UserUploadedFileBusinessRules userUploadedFileBusinessRules)
        {
            _mapper = mapper;
            _userUploadedFileRepository = userUploadedFileRepository;
            _userUploadedFileBusinessRules = userUploadedFileBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedUserUploadedFileResponse>> Handle(DeleteUserUploadedFileCommand request, CancellationToken cancellationToken)
        {
            UserUploadedFile? userUploadedFile = await _userUploadedFileRepository.GetAsync(predicate: uuf => uuf.Id == request.Id, cancellationToken: cancellationToken);
            await _userUploadedFileBusinessRules.UserUploadedFileShouldExistWhenSelected(userUploadedFile);

            await _userUploadedFileRepository.DeleteAsync(userUploadedFile!);

            DeletedUserUploadedFileResponse response = _mapper.Map<DeletedUserUploadedFileResponse>(userUploadedFile);

             return CustomResponseDto<DeletedUserUploadedFileResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}