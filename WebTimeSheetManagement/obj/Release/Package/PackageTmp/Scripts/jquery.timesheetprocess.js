function Approvetimesheet() {
    if (confirm('Are you sure you want to Approve Expense?'))
    {
        if ($("#Comment").val() == '')
        {
            alert("Please Enter Comment");
            return false;
        }
        else {

            var TimeSheetModel =
                {
                    TimeSheetMasterID: $("#TimeSheetMasterID").val(),
                    Comment: $("#Comment").val(),
                };

            var url = '/ShowAllTimeSheet/Approval';
            $.post(url, { TimeSheetApproval: TimeSheetModel }, function (data) {
                if (data) {
                    alert("Timesheet Approved Successfully");
                    window.location.href = "/ShowAllTimeSheet/TimeSheet";
                    return true;
                }
                else {
                    alert("Something Went Wrong!");
                    return false;
                }
            });
        }
    }
    else {
        return false;
    }
}

function Rejecttimesheet() {

    if (confirm('Are you sure you want to Reject Expense?')) {
        if ($("#Comment").val() == '') {
            alert("Please Enter Comment");
            return false;
        }
        else {

            var TimeSheetModel =
               {
                   TimeSheetMasterID: $("#TimeSheetMasterID").val(),
                   Comment: $("#Comment").val(),
               };

            var url = '/ShowAllTimeSheet/Rejected';
            $.post(url, { TimeSheetApproval: TimeSheetModel }, function (data) {
                if (data) {
                    alert("Timesheet Rejected Successfully");
                    window.location.href = "/ShowAllTimeSheet/TimeSheet";
                    return true;
                }
                else {
                    alert("Something Went Wrong!");
                }
            });

        }
    }
    else {
        return false;
    }
}