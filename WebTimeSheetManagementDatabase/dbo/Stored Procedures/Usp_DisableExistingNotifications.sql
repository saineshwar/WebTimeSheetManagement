Create Proc [dbo].[Usp_DisableExistingNotifications]
as
begin

update NotificationsTB
set NotificationsTB.Status ='D'

end
