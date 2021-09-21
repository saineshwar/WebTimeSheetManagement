CREATE TABLE [dbo].[Expense] (
    [ExpenseID]       INT           IDENTITY (1, 1) NOT NULL,
    [PurposeorReason] VARCHAR (50)  NULL,
    [ExpenseStatus]   INT           NULL,
    [FromDate]        DATE          NULL,
    [ToDate]          DATE          NULL,
    [VoucherID]       VARCHAR (50)  NULL,
    [HotelBills]      INT           NULL,
    [TravelBills]     INT           NULL,
    [MealsBills]      INT           NULL,
    [LandLineBills]   INT           NULL,
    [TransportBills]  INT           NULL,
    [MobileBills]     INT           NULL,
    [Miscellaneous]   INT           NULL,
    [TotalAmount]     INT           NULL,
    [UserID]          INT           NULL,
    [CreatedOn]       DATETIME      NULL,
    [Comment]         VARCHAR (100) NULL,
    [ProjectID]       INT           NULL,
    CONSTRAINT [PK_Expense] PRIMARY KEY CLUSTERED ([ExpenseID] ASC)
);

