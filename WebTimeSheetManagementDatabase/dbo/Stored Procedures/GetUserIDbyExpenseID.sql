create Proc [dbo].[GetUserIDbyExpenseID]
@ExpenseID int
as
begin
select top 1 UserID from Expense where ExpenseID =@ExpenseID
end
