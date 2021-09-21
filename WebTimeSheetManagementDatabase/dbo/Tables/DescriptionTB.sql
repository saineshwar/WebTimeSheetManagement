CREATE TABLE [dbo].[DescriptionTB] (
    [DescriptionID]     INT           IDENTITY (1, 1) NOT NULL,
    [Description]       VARCHAR (100) NULL,
    [ProjectID]         INT           NULL,
    [TimeSheetMasterID] INT           NULL,
    [CreatedOn]         DATETIME      NULL,
    [UserID]            INT           NULL,
    CONSTRAINT [PK_DescriptionTB] PRIMARY KEY CLUSTERED ([DescriptionID] ASC)
);

