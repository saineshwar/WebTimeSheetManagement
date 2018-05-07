using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTimeSheetManagement.Models
{
    public class TimeSheetDetailsView
    {
        public int TimeSheetID { get; set; }
        public string DaysofWeek { get; set; }
        public int? Hours { get; set; }
        public string Period { get; set; }
        public int? ProjectID { get; set; }
        public int UserID { get; set; }
        public string CreatedOn { get; set; }
        public int TimeSheetMasterID { get; set; }
        public string ProjectName { get; set; }

    }

    public class MainTimeSheetView
    {
        public List<TimeSheetDetailsView> ListTimeSheetDetails { get; set; }
        public  List<GetPeriods> ListofPeriods { get; set; }
        public List<GetProjectNames> ListofProjectNames { get; set; }
        public List<string> ListoDayofWeek { get; set; }
        public int TimeSheetMasterID { get; set; }
    }

}
