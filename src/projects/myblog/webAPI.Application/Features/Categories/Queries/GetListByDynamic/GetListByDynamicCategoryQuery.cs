using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace webAPI.Application.Features.Categories.Queries.GetListByDynamic
{
    public class GetListByDynamicCategoryQuery : IRequest<CustomResponseDto<CategoryListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public DynamicQuery? DynamicQuery { get; set; }

        public GetListByDynamicCategoryQuery()
        {
            PageRequest = default!;
            DynamicQuery = default!;
        }

        public class GetListByDynamicCategoryQueryHandler : IRequestHandler<GetListByDynamicCategoryQuery, CustomResponseDto<CategoryListModel>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public GetListByDynamicCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<CustomResponseDto<CategoryListModel>> Handle(GetListByDynamicCategoryQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Category> categories = await _categoryRepository.GetListByDynamicAsync(
                      dynamic: request.DynamicQuery,
                      index: request.PageRequest.PageIndex,
                      size: request.PageRequest.PageSize,
                      include: i => i.Include(i => i.CategoryUploadedFiles));

                CategoryListModel mappedCategoryListModel = _mapper.Map<CategoryListModel>(categories);
                return CustomResponseDto<CategoryListModel>.Success((int)HttpStatusCode.OK, mappedCategoryListModel, true);
            }
        }
    }
}
