CREATE proc [dbo].[Usp_GetHoursbyTimeSheetMasterID]    
@TimeSheetMasterID int   ,
@ProjectID int 
as    
begin    
    
SELECT     
      Hours 
  FROM [TimeSheetDetails]     
  where TimeSheetMasterID =@TimeSheetMasterID and ProjectID =@ProjectID
  
  union all
  
  SELECT     
      SUM(Hours) 
  FROM [TimeSheetDetails]     
  where TimeSheetMasterID =@TimeSheetMasterID and ProjectID =@ProjectID 
end
