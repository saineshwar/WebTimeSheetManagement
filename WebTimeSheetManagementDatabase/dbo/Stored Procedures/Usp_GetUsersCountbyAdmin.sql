Create proc [dbo].[Usp_GetUsersCountbyAdmin]
@AdminID int 
as
begin
Select Count (1) as UsersCount FROM AssignedRoles where AssignToAdmin =@AdminID  
end
