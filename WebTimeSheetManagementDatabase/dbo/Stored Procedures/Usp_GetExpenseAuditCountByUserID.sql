Create proc [dbo].[Usp_GetExpenseAuditCountByUserID]
@UserID int   
as  
begin  
 select UserID,  
    count(case when Status = 1 then 1 else NULL end) SubmittedCount,  
    count(case when Status = 2 then 1 else NULL end) ApprovedCount,  
    count(case when Status = 3 then 1 else NULL end) RejectedCount  
from ExpenseAuditTB  
where UserID = @UserID   
group by UserID  
end
