CREATE SERVICE [SqlQueryNotificationService-d78299b8-77ec-4dae-93fc-8e458c0b2e45]
    AUTHORIZATION [dbo]
    ON QUEUE [dbo].[SqlQueryNotificationService-d78299b8-77ec-4dae-93fc-8e458c0b2e45]
    ([http://schemas.microsoft.com/SQL/Notifications/PostQueryNotification]);

