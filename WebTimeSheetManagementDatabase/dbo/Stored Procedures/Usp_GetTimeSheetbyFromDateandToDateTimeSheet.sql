CREATE proc [dbo].[Usp_GetTimeSheetbyFromDateandToDateTimeSheet]  
@FromDate date = null,  
@ToDate date  = null
as  
begin  
  
SELECT [TimeSheetMasterID]  
FROM [TimesheetDB].[dbo].[TimeSheetMaster]  
where FromDate  between @FromDate and @ToDate 
end
