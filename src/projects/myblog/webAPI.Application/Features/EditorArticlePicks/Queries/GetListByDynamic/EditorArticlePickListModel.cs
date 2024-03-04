using Application.Features.EditorArticlePicks.Queries.GetList;
using Core.Persistence.Paging;

namespace webAPI.Application.Features.EditorArticlePicks.Queries.GetListByDynamic
{
    public class EditorArticlePickListModel : BasePageableModel
    {
        public IList<GetListEditorArticlePickListItemDto> Items { get; set; }

        public EditorArticlePickListModel()
        {
            Items = [];
        }
    }
}
