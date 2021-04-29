Create proc [dbo].[Usp_GetProjectCount]
as
begin
  Select Count (1) as ProjectCount FROM [TimesheetDB].[dbo].[ProjectMaster]
  end
