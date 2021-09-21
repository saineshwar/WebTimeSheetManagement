CREATE proc [dbo].[Usp_GetUsersCountbyAdminByAdminID] 
@AdminID int 
as
begin
 select ApprovalUser,
    count(case when Status = 1 then 1 else NULL end) SubmittedCount,
    count(case when Status = 2 then 1 else NULL end) ApprovedCount,
    count(case when Status = 3 then 1 else NULL end) RejectedCount
from TimeSheetAuditTB
where ApprovalUser = @AdminID 
group by ApprovalUser
end
