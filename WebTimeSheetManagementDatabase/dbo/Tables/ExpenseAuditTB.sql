CREATE TABLE [dbo].[ExpenseAuditTB] (
    [ApprovaExpenselLogID] INT           IDENTITY (1, 1) NOT NULL,
    [ApprovalUser]         INT           NULL,
    [ProcessedDate]        DATETIME      NULL,
    [CreatedOn]            DATETIME      NULL,
    [Comment]              VARCHAR (100) NULL,
    [Status]               INT           NULL,
    [ExpenseID]            INT           NULL,
    [UserID]               INT           NULL,
    CONSTRAINT [PK_ExpenseAuditTB] PRIMARY KEY CLUSTERED ([ApprovaExpenselLogID] ASC)
);

