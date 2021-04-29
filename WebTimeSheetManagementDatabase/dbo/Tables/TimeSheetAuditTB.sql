CREATE TABLE [dbo].[TimeSheetAuditTB] (
    [ApprovalTimeSheetLogID] INT           IDENTITY (1, 1) NOT NULL,
    [ApprovalUser]           INT           NULL,
    [ProcessedDate]          DATETIME      NULL,
    [CreatedOn]              DATETIME      NULL,
    [Comment]                VARCHAR (100) NULL,
    [Status]                 INT           NULL,
    [TimeSheetID]            INT           NULL,
    [UserID]                 INT           NULL,
    CONSTRAINT [PK_TimeSheetAuditTB] PRIMARY KEY CLUSTERED ([ApprovalTimeSheetLogID] ASC)
);

