CREATE proc [dbo].[Usp_GetReportofExpense]    
@FromDate date = null,      
@ToDate date  = null,  
@AssignTo int        
as    
begin    
    
SELECT     
       PM.ProjectName           
      ,[PurposeorReason]    
      ,Reg.Name    
      ,case when ExpenseStatus =1 then 'Submitted' when ExpenseStatus =2 then 'Approved' when ExpenseStatus =3 then 'Rejected' end as Status    
      ,EA.Comment as Comment   
      ,[FromDate]    
      ,[ToDate]    
      ,[VoucherID]    
      ,[HotelBills]    
      ,[TravelBills]    
      ,[MealsBills]    
      ,[LandLineBills]    
      ,[TransportBills]    
      ,[MobileBills]    
      ,[Miscellaneous]    
      ,[TotalAmount]    
      ,ex.CreatedOn        
  FROM [TimesheetDB].[dbo].[Expense] ex    
  inner join Registration Reg on reg.RegistrationID = ex.UserID    
  inner join ProjectMaster PM on ex.ProjectID =PM.ProjectID 
  inner join AssignedRoles AR on reg.RegistrationID = AR.RegistrationID   
  inner join ExpenseAuditTB EA on ex.ExpenseID = EA.ExpenseID 
  where FromDate  between @FromDate and @ToDate and AR.AssignToAdmin =@AssignTo and EA.Status = 2      
end
