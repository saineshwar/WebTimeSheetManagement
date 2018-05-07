using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTimeSheetManagement.Models;

namespace WebTimeSheetManagement.Interface
{
    public interface INotification
    {
        int AddNotification(NotificationsTB entity);
        void DisableExistingNotifications();
        IQueryable<NotificationsTB_ViewModel> ShowNotifications(string sortColumn, string sortColumnDir, string Search);

        bool DeActivateNotificationByID(int NotificationID);
    }
}
