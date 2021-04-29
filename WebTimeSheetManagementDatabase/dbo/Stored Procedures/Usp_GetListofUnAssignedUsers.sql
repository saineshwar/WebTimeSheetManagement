CREATE Proc [dbo].[Usp_GetListofUnAssignedUsers]      
      
as      
begin      
      
select * from dbo.Registration R       
where R.RoleID =2 and r.RegistrationID not in (
Select RegistrationID from dbo.AssignedRoles
)    
      
      
--RoleID Rolename      
--1 Admin      
--2 Users      
--3 SuperAdmin      
end
