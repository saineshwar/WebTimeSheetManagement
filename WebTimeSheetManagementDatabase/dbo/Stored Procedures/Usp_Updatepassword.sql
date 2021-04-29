Create proc [dbo].[Usp_Updatepassword]
@NewPassword varchar(100),
@UserID int
as
begin

update Registration 
set Password = @NewPassword
where Registration.RegistrationID = @UserID  
  
end
