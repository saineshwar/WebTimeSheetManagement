CREATE proc [dbo].[Usp_GetWeekTimeSheetDetails]
@TimeSheetMasterID int
as
begin
select TM.DaysofWeek
      ,TM.Hours
      ,TM.Period
      ,PM.ProjectName
      ,TM.CreatedOn
      from TimeSheetDetails TM
Inner join ProjectMaster PM on TM.ProjectID = PM.ProjectID 
where TimeSheetMasterID = @TimeSheetMasterID
end
