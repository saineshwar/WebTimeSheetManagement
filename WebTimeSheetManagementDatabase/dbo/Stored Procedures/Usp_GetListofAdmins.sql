CREATE proc [dbo].[Usp_GetListofAdmins]  
  
as  
begin  
select RegistrationID, UPPER(Name) as Name from Registration where RoleID = 1  
end
