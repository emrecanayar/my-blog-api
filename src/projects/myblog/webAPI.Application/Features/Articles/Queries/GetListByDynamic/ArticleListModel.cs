using Application.Features.Articles.Queries.GetList;
using Core.Persistence.Paging;

namespace webAPI.Application.Features.Articles.Queries.GetListByDynamic
{
    public class ArticleListModel : BasePageableModel
    {
        public IList<GetListArticleListItemDto> Items { get; set; }

        public ArticleListModel()
        {
            Items = default!;
        }
    }
}
