Create proc [dbo].[Usp_UpdateTimeSheetStatus]  
@TimeSheetMasterID int,  
@Comment varchar(100),  
@TimeSheetStatus int  
as  
begin  
update TimeSheetMaster  
set TimeSheetMaster.TimeSheetStatus =@TimeSheetStatus,  
TimeSheetMaster.Comment =@Comment  
where TimeSheetMaster.TimeSheetMasterID =@TimeSheetMasterID  
end
