CREATE TABLE [dbo].[Roles] (
    [RoleID]   INT           IDENTITY (1, 1) NOT NULL,
    [Rolename] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([RoleID] ASC)
);

