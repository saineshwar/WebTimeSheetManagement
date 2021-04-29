CREATE Proc [dbo].[GetUserIDbyTimeSheetID]
@TimeSheetMasterID int
as
begin
select top 1 UserID from TimeSheetMaster where TimeSheetMasterID =@TimeSheetMasterID
end
