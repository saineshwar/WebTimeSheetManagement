CREATE TABLE [dbo].[ELMAH_Error] (
    [ErrorId]     UNIQUEIDENTIFIER CONSTRAINT [DF_ELMAH_Error_ErrorId] DEFAULT (newid()) NOT NULL,
    [Application] NVARCHAR (60)    NOT NULL,
    [Host]        NVARCHAR (50)    NOT NULL,
    [Type]        NVARCHAR (100)   NOT NULL,
    [Source]      NVARCHAR (60)    NOT NULL,
    [Message]     NVARCHAR (500)   NOT NULL,
    [User]        NVARCHAR (50)    NOT NULL,
    [StatusCode]  INT              NOT NULL,
    [TimeUtc]     DATETIME         NOT NULL,
    [Sequence]    INT              IDENTITY (1, 1) NOT NULL,
    [AllXml]      NTEXT            NOT NULL,
    CONSTRAINT [PK_ELMAH_Error] PRIMARY KEY NONCLUSTERED ([ErrorId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_ELMAH_Error_App_Time_Seq]
    ON [dbo].[ELMAH_Error]([Application] ASC, [TimeUtc] DESC, [Sequence] DESC);

