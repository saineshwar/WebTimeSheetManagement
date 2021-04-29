CREATE proc [dbo].[Usp_UpdateUserRole]  
@RegistrationID int  
as      
begin      
Delete from AssignedRoles where RegistrationID = @RegistrationID  
end
