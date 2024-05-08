using Application.Features.Categories.Constants;
using Application.Services.Categories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Dtos;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;
using static Application.Features.Categories.Constants.CategoriesOperationClaims;

namespace Application.Features.Categories.Commands.Create;

public class CreateCategoryCommand : BaseFileTokenDto, IRequest<CustomResponseDto<CreatedCategoryResponse>>, ISecuredRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsPopular { get; set; }
    [JsonIgnore]
    public string? WebRootPath { get; set; }

    public string[] Roles => [Admin, Write, CategoriesOperationClaims.Create];

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CustomResponseDto<CreatedCategoryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoriesService _categoriesService;

        public CreateCategoryCommandHandler(IMapper mapper, ICategoriesService categoriesService)
        {
            _mapper = mapper;
            _categoriesService = categoriesService;
        }

        public async Task<CustomResponseDto<CreatedCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoriesService.AddCategoryWithFileAsync(request);
            CreatedCategoryResponse response = _mapper.Map<CreatedCategoryResponse>(category);
            return CustomResponseDto<CreatedCategoryResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}