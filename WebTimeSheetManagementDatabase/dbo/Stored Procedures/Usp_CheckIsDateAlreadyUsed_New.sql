CREATE Proc [dbo].[Usp_CheckIsDateAlreadyUsed_New]
@FromDate datetime,
@ToDate datetime,
@UserID int
as
begin

SELECT COUNT(1)
  FROM [TimesheetDB].[dbo].[TimeSheet_New]
  where ToDateTime between @FromDate and @ToDate and UserID =@UserID
end
