using Application.Features.UserUploadedFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.UserUploadedFiles.Queries.GetById;

public class GetByIdUserUploadedFileQuery : IRequest<CustomResponseDto<GetByIdUserUploadedFileResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdUserUploadedFileQueryHandler : IRequestHandler<GetByIdUserUploadedFileQuery, CustomResponseDto<GetByIdUserUploadedFileResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserUploadedFileRepository _userUploadedFileRepository;
        private readonly UserUploadedFileBusinessRules _userUploadedFileBusinessRules;

        public GetByIdUserUploadedFileQueryHandler(IMapper mapper, IUserUploadedFileRepository userUploadedFileRepository, UserUploadedFileBusinessRules userUploadedFileBusinessRules)
        {
            _mapper = mapper;
            _userUploadedFileRepository = userUploadedFileRepository;
            _userUploadedFileBusinessRules = userUploadedFileBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdUserUploadedFileResponse>> Handle(GetByIdUserUploadedFileQuery request, CancellationToken cancellationToken)
        {
            UserUploadedFile? userUploadedFile = await _userUploadedFileRepository.GetAsync(predicate: uuf => uuf.Id == request.Id, cancellationToken: cancellationToken);
            await _userUploadedFileBusinessRules.UserUploadedFileShouldExistWhenSelected(userUploadedFile);

            GetByIdUserUploadedFileResponse response = _mapper.Map<GetByIdUserUploadedFileResponse>(userUploadedFile);

          return CustomResponseDto<GetByIdUserUploadedFileResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}