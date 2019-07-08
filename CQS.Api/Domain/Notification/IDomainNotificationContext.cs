namespace CQS.Api.Domain.Notification
{
    public interface IDomainNotificationContext
    {
        bool HasNotifications { get; }

        void NotifyError(string message);
        void NotifySuccess(string message);
    }
}