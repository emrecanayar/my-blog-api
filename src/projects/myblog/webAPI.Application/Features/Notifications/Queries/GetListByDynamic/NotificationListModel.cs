using Application.Features.Notifications.Queries.GetList;
using Core.Persistence.Paging;

namespace webAPI.Application.Features.Notifications.Queries.GetListByDynamic
{
    public class NotificationListModel : BasePageableModel
    {
        public IList<GetListNotificationListItemDto> Items { get; set; }
        public NotificationListModel()
        {
            Items = [];
        }
    }
}
