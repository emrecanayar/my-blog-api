using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using static Application.Features.Categories.Constants.CategoriesOperationClaims;

namespace Application.Features.Categories.Queries.GetById;

public class GetByIdCategoryQuery : IRequest<CustomResponseDto<GetByIdCategoryResponse>>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CustomResponseDto<GetByIdCategoryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public GetByIdCategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository, CategoryBusinessRules categoryBusinessRules)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCategoryResponse>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            Category? category = await _categoryRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryBusinessRules.CategoryShouldExistWhenSelected(category);

            GetByIdCategoryResponse response = _mapper.Map<GetByIdCategoryResponse>(category);

            return CustomResponseDto<GetByIdCategoryResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}