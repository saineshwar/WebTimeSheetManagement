CREATE Proc [dbo].[Usp_CheckIsDateAlreadyUsed]
@FromDate date,
@ToDate date,
@UserID int
as
begin

SELECT COUNT(1)
  FROM [TimesheetDB].[dbo].[Expense]
  where ToDate between @FromDate and @ToDate and UserID =@UserID
end
