CREATE TABLE [dbo].[ProjectMaster] (
    [ProjectID]        INT           IDENTITY (1, 1) NOT NULL,
    [ProjectName]      VARCHAR (100) NULL,
    [NatureofIndustry] VARCHAR (100) NULL,
    [ProjectCode]      VARCHAR (10)  NULL,
    CONSTRAINT [PK_ProjectMaster] PRIMARY KEY CLUSTERED ([ProjectID] ASC)
);

