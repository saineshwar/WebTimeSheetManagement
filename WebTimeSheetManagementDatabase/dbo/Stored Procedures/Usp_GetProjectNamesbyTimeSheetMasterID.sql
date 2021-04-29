Create proc [dbo].[Usp_GetProjectNamesbyTimeSheetMasterID]
@TimeSheetMasterID int
as
begin

  SELECT 
      TM.ProjectID,
      PM.ProjectName
  FROM [TimeSheetDetails] TM
  inner join ProjectMaster PM on TM.ProjectID =PM.ProjectID 
  where  TM.TimeSheetMasterID =@TimeSheetMasterID 
  group by TM.[ProjectID],PM.ProjectName
end
