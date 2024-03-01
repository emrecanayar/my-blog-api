using Application.Features.Comments.Queries.GetList;
using Core.Persistence.Paging;

namespace webAPI.Application.Features.Comments.Queries.GetListByDynamic
{
    public class CommentListModel : BasePageableModel
    {
        public IList<GetListCommentListItemDto> Items { get; set; }

        public CommentListModel()
        {
            Items = [];
        }
    }
}
