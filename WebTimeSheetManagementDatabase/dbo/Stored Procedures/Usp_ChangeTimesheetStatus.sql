CREATE proc [dbo].[Usp_ChangeTimesheetStatus]
@Status int,
@TimeSheetID int,
@Comment varchar(100)
as
begin
Update dbo.TimeSheetAuditTB
set 
Status = @Status,
Comment = @Comment,
ProcessedDate =getdate()
where TimeSheetID = @TimeSheetID and Status <> 1
end
