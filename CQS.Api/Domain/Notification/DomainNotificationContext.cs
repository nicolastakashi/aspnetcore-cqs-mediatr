﻿using System.Collections.Generic;
using System.Linq;

namespace CQS.Api.Domain.Notification
{
    public class DomainNotificationContext : IDomainNotificationContext
    {
        private readonly List<DomainNotification> _notifications;

        public DomainNotificationContext()
        {
            _notifications = new List<DomainNotification>();
        }

        public bool HasNotifications
            => _notifications.Any();

        public void NotifySuccess(string message)
            => Notify(message, DomainNotificationType.Success);

        public void NotifyError(string message)
            => Notify(message, DomainNotificationType.Error);

        private void Notify(string message, DomainNotificationType type)
            => _notifications.Add(new DomainNotification(type, message));
    }
}