Create proc [dbo].[Usp_UpdateExpenseStatus]
@ExpenseID int,
@Comment varchar(100),
@ExpenseStatus int
as
begin
update Expense
set Expense.ExpenseStatus =@ExpenseStatus,
Expense.Comment =@Comment
where Expense.ExpenseID =@ExpenseID
end
