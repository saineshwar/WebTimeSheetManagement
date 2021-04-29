Create proc [dbo].[Usp_GetAdminCount]
as
begin
Select Count (1) as AdminCount FROM [TimesheetDB].[dbo].[Registration] where RoleID =1
end
