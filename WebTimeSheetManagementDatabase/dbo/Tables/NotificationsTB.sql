CREATE TABLE [dbo].[NotificationsTB] (
    [NotificationsID] INT          IDENTITY (1, 1) NOT NULL,
    [Status]          VARCHAR (50) NULL,
    [Message]         VARCHAR (50) NULL,
    [CreatedOn]       DATETIME     NULL,
    [FromDate]        DATETIME     NULL,
    [ToDate]          DATETIME     NULL,
    CONSTRAINT [PK_NotificationsTB] PRIMARY KEY CLUSTERED ([NotificationsID] ASC)
);

