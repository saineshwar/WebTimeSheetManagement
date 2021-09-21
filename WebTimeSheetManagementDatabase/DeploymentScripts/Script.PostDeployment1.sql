/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
Exec Populate_dbo_TimeSheetMaster
Exec Populate_dbo_TimeSheetDetails
Exec Populate_dbo_TimeSheetAuditTB
Exec Populate_dbo_Roles
Exec Populate_dbo_Registration
Exec Populate_dbo_ProjectMaster
Exec Populate_dbo_NotificationsTB
Exec Populate_dbo_ExpenseAuditTB
Exec Populate_dbo_Expense
--Exec Populate_dbo_ELMAH_Error
Exec Populate_dbo_Documents
Exec Populate_dbo_AuditTB
Exec Populate_dbo_AssignedRoles

Drop Procedure Populate_dbo_TimeSheetMaster
Drop Procedure Populate_dbo_TimeSheetDetails
Drop Procedure Populate_dbo_TimeSheetAuditTB
Drop Procedure Populate_dbo_Roles
Drop Procedure Populate_dbo_Registration
Drop Procedure Populate_dbo_ProjectMaster
Drop Procedure Populate_dbo_NotificationsTB
Drop Procedure Populate_dbo_ExpenseAuditTB
Drop Procedure Populate_dbo_Expense
Drop Procedure Populate_dbo_ELMAH_Error
Drop Procedure Populate_dbo_Documents
Drop Procedure Populate_dbo_AuditTB
Drop Procedure Populate_dbo_AssignedRoles





