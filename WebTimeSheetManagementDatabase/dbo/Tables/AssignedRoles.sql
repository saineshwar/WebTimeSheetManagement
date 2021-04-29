CREATE TABLE [dbo].[AssignedRoles] (
    [AssignedRolesID] INT         IDENTITY (1, 1) NOT NULL,
    [AssignToAdmin]   INT         NULL,
    [Status]          VARCHAR (1) NULL,
    [CreatedOn]       DATETIME    NULL,
    [CreatedBy]       INT         NULL,
    [RegistrationID]  INT         NULL,
    CONSTRAINT [PK_AssignedRoles] PRIMARY KEY CLUSTERED ([AssignedRolesID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'It is Registration Table  RegistrationID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AssignedRoles';

