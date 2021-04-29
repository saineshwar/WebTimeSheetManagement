CREATE proc [dbo].[Usp_GetTimeSheetMasterIDTimeSheet]  
@FromDate Date = null,  
@ToDate Date  = null,  
@UserID int  
as  
begin  
  

SELECT [TimeSheetMasterID]  
FROM [TimesheetDB].[dbo].[TimeSheetMaster]  
where FromDate  between @FromDate and @ToDate and UserID = @UserID  
end
