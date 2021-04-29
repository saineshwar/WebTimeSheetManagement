CREATE proc [dbo].[Usp_DeleteTimeSheet]
@TimeSheetID int,
@UserID int
as
begin

Delete from TimeSheetMaster where TimeSheetMasterID =@TimeSheetID and UserID =@UserID

if exists (select TimeSheetID from dbo.TimeSheetDetails where TimeSheetID =@TimeSheetID and UserID =@UserID)
begin
Delete from TimeSheetDetails where TimeSheetID =@TimeSheetID and UserID =@UserID
end

if exists (select TimeSheetID from dbo.TimeSheetAuditTB where TimeSheetID =@TimeSheetID and UserID =@UserID)
begin
Delete from TimeSheetAuditTB where TimeSheetID =@TimeSheetID and UserID =@UserID
end

end
