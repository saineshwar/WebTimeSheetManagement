CREATE proc [dbo].[Usp_DeleteExpenseandDocuments]  
@ExpenseID int ,
@UserID int 
as  
begin  
Delete from Expense where ExpenseID =@ExpenseID and UserID =@UserID  
  
if exists (select DocumentID from dbo.Documents where ExpenseID =@ExpenseID and UserID =@UserID )  
begin  
Delete from Documents where ExpenseID =@ExpenseID and UserID =@UserID  
end  
  
if exists (select ApprovaExpenselLogID from dbo.ExpenseAuditTB where ExpenseID =@ExpenseID and UserID =@UserID)  
begin  
Delete from ExpenseAuditTB where ExpenseID =@ExpenseID and UserID =@UserID  
end  
  
  
end
