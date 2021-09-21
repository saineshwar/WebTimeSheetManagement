CREATE proc [dbo].[Usp_GetAllReportofExpense]    
@FromDate date = null,      
@ToDate date  = null
  
as    
begin    
    
SELECT     
       PM.ProjectName           
      ,[PurposeorReason]    
      ,Reg.Name    
      ,case when ExpenseStatus =1 then 'Submitted' when ExpenseStatus =2 then 'Approved' when ExpenseStatus =3 then 'Rejected' end as Status    
      ,[Comment]    
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
  where FromDate  between @FromDate and @ToDate  
end
