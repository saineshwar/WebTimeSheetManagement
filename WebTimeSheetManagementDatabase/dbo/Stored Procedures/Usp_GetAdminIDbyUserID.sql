Create Proc [dbo].[Usp_GetAdminIDbyUserID]
@UserID int
as
begin
SELECT 
      [AssignToAdmin]
  FROM [TimesheetDB].[dbo].[AssignedRoles] where RegistrationID = @UserID
end
