using Application.Features.Categories.Queries.GetList;
using Core.Persistence.Paging;

namespace webAPI.Application.Features.Categories.Queries.GetListByDynamic
{
    public class CategoryListModel : BasePageableModel
    {
        public IList<GetListCategoryListItemDto> Items { get; set; }

        public CategoryListModel()
        {
            Items = default!;
        }
    }
}
