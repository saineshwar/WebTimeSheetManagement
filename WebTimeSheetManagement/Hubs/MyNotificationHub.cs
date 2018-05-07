using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebTimeSheetManagement.Hubs
{

    [HubName("mynotificationHub")]
    public class MyNotificationHub : Hub
    {
        public static void Send()
        {
            try
            {
                IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyNotificationHub>();
                context.Clients.All.displayStatus();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}