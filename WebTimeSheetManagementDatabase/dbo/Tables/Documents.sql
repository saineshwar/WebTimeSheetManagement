CREATE TABLE [dbo].[Documents] (
    [DocumentID]    INT             IDENTITY (1, 1) NOT NULL,
    [DocumentName]  VARCHAR (50)    NULL,
    [DocumentBytes] VARBINARY (MAX) NULL,
    [UserID]        INT             NULL,
    [CreatedOn]     DATETIME        NULL,
    [ExpenseID]     INT             NULL,
    [DocumentType]  VARCHAR (10)    NULL,
    CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED ([DocumentID] ASC)
);

