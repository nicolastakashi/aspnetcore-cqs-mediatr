using System.Collections.Generic;

namespace CQS.Api.Domain.Notification
{
    public interface IDomainNotificationContext
    {
        bool HasErrorNotifications { get; }
        void NotifyError(string message);
        void NotifySuccess(string message);
        List<DomainNotification> GetErrorNotifications();
    }
}