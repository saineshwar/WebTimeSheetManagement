CREATE TABLE [dbo].[AuditTB] (
    [AuditID]        INT           IDENTITY (1, 1) NOT NULL,
    [UserID]         VARCHAR (50)  NULL,
    [SessionID]      VARCHAR (50)  NULL,
    [IPAddress]      VARCHAR (50)  NULL,
    [PageAccessed]   VARCHAR (200) NULL,
    [LoggedInAt]     DATETIME      NULL,
    [LoggedOutAt]    DATETIME      NULL,
    [LoginStatus]    VARCHAR (200) NULL,
    [ControllerName] VARCHAR (200) NULL,
    [ActionName]     VARCHAR (200) NULL,
    [UrlReferrer]    VARCHAR (200) NULL,
    CONSTRAINT [PK_AuditTB] PRIMARY KEY CLUSTERED ([AuditID] ASC)
);

