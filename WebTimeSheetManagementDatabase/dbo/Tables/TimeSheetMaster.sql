CREATE TABLE [dbo].[TimeSheetMaster] (
    [TimeSheetMasterID] INT           IDENTITY (1, 1) NOT NULL,
    [FromDate]          DATE          NULL,
    [ToDate]            DATE          NULL,
    [TotalHours]        INT           NULL,
    [UserID]            INT           NULL,
    [CreatedOn]         DATETIME      NULL,
    [Comment]           VARCHAR (100) NULL,
    [TimeSheetStatus]   INT           NULL,
    CONSTRAINT [PK_TimeSheetMaster] PRIMARY KEY CLUSTERED ([TimeSheetMasterID] ASC)
);

