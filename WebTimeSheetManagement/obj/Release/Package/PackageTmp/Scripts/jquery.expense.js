function ApproveExpense() {
    if (confirm('Are you sure you want to Approve Expense?')) {
        if ($("#Comment").val() == '') {
            alert("Please Enter Comment");
            return false;
        }
        else {

            var ExpenseApprovalModel =
                {
                    ExpenseID: $("#ExpenseID").val(),
                    Comment: $("#Comment").val(),
                };

            var url = '/ShowAllExpense/Approval';
            $.post(url, { ExpenseApprovalModel: ExpenseApprovalModel }, function (data) {
                if (data)
                {
                    alert("Expense Approved Successfully");
                    window.location.href = "/ShowAllExpense/Expense";
                    return true;
                }
                else
                {
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

function RejectExpense() {

    if (confirm('Are you sure you want to Reject Expense?')) {
        if ($("#Comment").val() == '') {
            alert("Please Enter Comment");
            return false;
        }
        else {

            var ExpenseApprovalModel =
               {
                   ExpenseID: $("#ExpenseID").val(),
                   Comment: $("#Comment").val(),
               };

            var url = '/ShowAllExpense/Rejected';
            $.post(url, { ExpenseApprovalModel: ExpenseApprovalModel }, function (data)
            {
                if (data)
                {
                    alert("Expense Rejected Successfully");
                    window.location.href = "/ShowAllExpense/Expense";
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