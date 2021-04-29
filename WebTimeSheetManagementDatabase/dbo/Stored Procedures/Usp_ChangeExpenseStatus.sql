Create proc [dbo].[Usp_ChangeExpenseStatus]
@Status int,
@ExpenseID int,
@Comment varchar(100)
as
begin
Update dbo.ExpenseAuditTB
set 
Status = @Status,
Comment = @Comment,
ProcessedDate =getdate()
where ExpenseID = @ExpenseID and Status <> 1
end
