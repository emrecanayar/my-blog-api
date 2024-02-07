using Application.Features.Categories.Constants;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using static Application.Features.Categories.Constants.CategoriesOperationClaims;

namespace Application.Features.Categories.Commands.Create;

public class CreateCategoryCommand : IRequest<CustomResponseDto<CreatedCategoryResponse>>, ISecuredRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsPopular { get; set; }
    public Guid UploadedFileId { get; set; }

    public string[] Roles => new[] { Admin, Write, CategoriesOperationClaims.Create };

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CustomResponseDto<CreatedCategoryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository,
                                         CategoryBusinessRules categoryBusinessRules)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request);

            await _categoryRepository.AddAsync(category);

            CreatedCategoryResponse response = _mapper.Map<CreatedCategoryResponse>(category);
            return CustomResponseDto<CreatedCategoryResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}