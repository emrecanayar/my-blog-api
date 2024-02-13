using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Application.Features.Categories.Constants.CategoriesOperationClaims;

namespace Application.Features.Categories.Queries.GetList;

public class GetListCategoryQuery : IRequest<CustomResponseDto<GetListResponse<GetListCategoryListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public GetListCategoryQuery()
    {
        PageRequest = default!;

    }

    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, CustomResponseDto<GetListResponse<GetListCategoryListItemDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCategoryListItemDto>>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Category> categories = await _categoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: x => x.Include(x => x.CategoryUploadedFiles),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListCategoryListItemDto>>(categories);
            return CustomResponseDto<GetListResponse<GetListCategoryListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}