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

namespace Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommand : BaseFileTokenDto, IRequest<CustomResponseDto<UpdatedCategoryResponse>>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsPopular { get; set; }

    [JsonIgnore]
    public string? WebRootPath { get; set; }
    public string[] Roles => new[] { Admin, Write, CategoriesOperationClaims.Update };

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CustomResponseDto<UpdatedCategoryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoriesService _categoriesService;

        public UpdateCategoryCommandHandler(IMapper mapper, ICategoriesService categoriesService)
        {
            _mapper = mapper;
            _categoriesService = categoriesService;
        }

        public async Task<CustomResponseDto<UpdatedCategoryResponse>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoriesService.UpdateCategoryWithFileAsync(request);
            UpdatedCategoryResponse response = _mapper.Map<UpdatedCategoryResponse>(category);
            return CustomResponseDto<UpdatedCategoryResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}