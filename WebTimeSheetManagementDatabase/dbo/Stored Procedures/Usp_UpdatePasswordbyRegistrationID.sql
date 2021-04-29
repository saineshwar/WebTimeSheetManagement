CREATE Proc [dbo].[Usp_UpdatePasswordbyRegistrationID]
@RegistrationID int,
@Password varchar(100)
as
begin
Update Registration
set Registration.Password = @Password
where Registration.RegistrationID =@RegistrationID
end
