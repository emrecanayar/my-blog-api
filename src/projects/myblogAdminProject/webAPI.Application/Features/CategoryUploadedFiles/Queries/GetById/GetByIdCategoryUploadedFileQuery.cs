using Application.Features.CategoryUploadedFiles.Constants;
using Application.Features.CategoryUploadedFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CategoryUploadedFiles.Constants.CategoryUploadedFilesOperationClaims;

namespace Application.Features.CategoryUploadedFiles.Queries.GetById;

public class GetByIdCategoryUploadedFileQuery : IRequest<CustomResponseDto<GetByIdCategoryUploadedFileResponse>>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCategoryUploadedFileQueryHandler : IRequestHandler<GetByIdCategoryUploadedFileQuery, CustomResponseDto<GetByIdCategoryUploadedFileResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryUploadedFileRepository _categoryUploadedFileRepository;
        private readonly CategoryUploadedFileBusinessRules _categoryUploadedFileBusinessRules;

        public GetByIdCategoryUploadedFileQueryHandler(IMapper mapper, ICategoryUploadedFileRepository categoryUploadedFileRepository, CategoryUploadedFileBusinessRules categoryUploadedFileBusinessRules)
        {
            _mapper = mapper;
            _categoryUploadedFileRepository = categoryUploadedFileRepository;
            _categoryUploadedFileBusinessRules = categoryUploadedFileBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCategoryUploadedFileResponse>> Handle(GetByIdCategoryUploadedFileQuery request, CancellationToken cancellationToken)
        {
            CategoryUploadedFile? categoryUploadedFile = await _categoryUploadedFileRepository.GetAsync(predicate: cuf => cuf.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryUploadedFileBusinessRules.CategoryUploadedFileShouldExistWhenSelected(categoryUploadedFile);

            GetByIdCategoryUploadedFileResponse response = _mapper.Map<GetByIdCategoryUploadedFileResponse>(categoryUploadedFile);

          return CustomResponseDto<GetByIdCategoryUploadedFileResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}