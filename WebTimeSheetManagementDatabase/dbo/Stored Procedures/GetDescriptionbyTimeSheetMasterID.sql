CREATE proc [dbo].[GetDescriptionbyTimeSheetMasterID]      
@TimeSheetMasterID int   ,  
@ProjectID int   
as      
begin      

select Description from DescriptionTB where TimeSheetMasterID =@TimeSheetMasterID and ProjectID =@ProjectID  
end
