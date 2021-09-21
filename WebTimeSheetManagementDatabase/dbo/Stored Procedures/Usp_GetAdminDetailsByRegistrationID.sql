CREATE Proc [dbo].[Usp_GetAdminDetailsByRegistrationID]  
@RegistrationID int  
as  
begin  
select  
EmployeeID,    
Name,  
Mobileno,  
EmailID,  
Username,  
Case when Gender ='M' then 'Male'  when Gender ='F' then 'Female' End Gender,  
CONVERT(VARCHAR(10), Birthdate, 101) as Birthdate,  
CONVERT(VARCHAR(10), DateofJoining, 101) as DateofJoining  
from Registration where RoleID =1 and RegistrationID =@RegistrationID  
end
