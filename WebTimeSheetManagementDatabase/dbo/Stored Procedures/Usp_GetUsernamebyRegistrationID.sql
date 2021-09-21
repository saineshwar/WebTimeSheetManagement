CREATE proc [dbo].[Usp_GetUsernamebyRegistrationID]  
@RegistrationID int  
as  
begin  
SELECT   replace(Name, ' ', '')
FROM Registration  
where RegistrationID =@RegistrationID 
end
