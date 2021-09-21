CREATE TABLE [dbo].[TimeSheetDetails] (
    [TimeSheetID]       INT          IDENTITY (1, 1) NOT NULL,
    [DaysofWeek]        VARCHAR (50) NULL,
    [Hours]             INT          NULL,
    [Period]            DATE         NULL,
    [ProjectID]         INT          NULL,
    [UserID]            INT          NULL,
    [CreatedOn]         DATETIME     NULL,
    [TimeSheetMasterID] INT          NULL,
    [TotalHours]        INT          NULL,
    CONSTRAINT [PK_TimeSheetDetails] PRIMARY KEY CLUSTERED ([TimeSheetID] ASC)
);

