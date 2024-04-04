using Core.Persistence.Paging;

namespace webAPI.Application.Features.Articles.Queries.GetListByDynamicForSearch
{
    public class ArticleSearchListModel : BasePageableModel
    {
        public IList<GetListArticleForSearchListItemDto> Items { get; set; }

        public ArticleSearchListModel()
        {
            Items = [];
        }
    }
}
