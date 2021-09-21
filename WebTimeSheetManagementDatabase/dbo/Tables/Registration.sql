CREATE TABLE [dbo].[Registration] (
    [RegistrationID]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]                VARCHAR (100) NULL,
    [Mobileno]            VARCHAR (20)  NULL,
    [EmailID]             VARCHAR (100) NULL,
    [Username]            VARCHAR (20)  NULL,
    [Password]            VARCHAR (100) NULL,
    [ConfirmPassword]     VARCHAR (100) NULL,
    [Gender]              VARCHAR (10)  NULL,
    [Birthdate]           DATETIME      NULL,
    [RoleID]              INT           NULL,
    [CreatedOn]           DATETIME      NULL,
    [EmployeeID]          VARCHAR (10)  NULL,
    [DateofJoining]       DATE          NULL,
    [ForceChangePassword] INT           NULL,
    CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED ([RegistrationID] ASC)
);

