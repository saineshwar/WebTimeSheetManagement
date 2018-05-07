function CalculateTotalonRun() {
    var Total = 0;
    var HotelAmount = 0;
    var TravelAmount = 0;
    var MealAmount = 0;
    var LandLineAmount = 0;
    var TransportAmount = 0;
    var MobileAmount = 0;
    var MiscellaneousAmount = 0;
    var TotalAmount = 0;

    HotelAmount = $("#HotelBills").val() == '' ? 0 : $("#HotelBills").val();

    TravelAmount = $("#TravelBills").val() == '' ? 0 : $("#TravelBills").val();

    MealAmount = $("#MealsBills").val() == '' ? 0 : $("#MealsBills").val();

    LandLineAmount = $("#LandLineBills").val() == '' ? 0 : $("#LandLineBills").val();

    TransportAmount = $("#TransportBills").val() == '' ? 0 : $("#TransportBills").val();

    MobileAmount = $("#MobileBills").val() == '' ? 0 : $("#MobileBills").val();

    MiscellaneousAmount = $("#Miscellaneous").val() == '' ? 0 : $("#Miscellaneous").val();

    TotalAmount = parseInt(HotelAmount) +
              parseInt(TravelAmount) +
              parseInt(MealAmount) +
              parseInt(LandLineAmount) +
              parseInt(TransportAmount) +
              parseInt(MobileAmount) +
              parseInt(MiscellaneousAmount);

    $("#TotalAmount").val(TotalAmount);

}

function onlyNumbers(evt) {

    flag = false
    var e = evt; // for trans-browser compatibility
    var charCode = e.which || e.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        //alert("Only numbers are allowed");
        return false;
    }
    return true;
}


function ValidateData() {

    if (confirm('Are you sure you want to save data?')) {

        var Total = 0;
        var HotelAmount = 0;
        var TravelAmount = 0;
        var MealAmount = 0;
        var LandLineAmount = 0;
        var TransportAmount = 0;
        var MobileAmount = 0;
        var MiscellaneousAmount = 0;
        var TotalAmount = 0;

        HotelAmount = $("#HotelBills").val() == '' ? 0 : $("#HotelBills").val();

        TravelAmount = $("#TravelBills").val() == '' ? 0 : $("#TravelBills").val();

        MealAmount = $("#MealsBills").val() == '' ? 0 : $("#MealsBills").val();

        LandLineAmount = $("#LandLineBills").val() == '' ? 0 : $("#LandLineBills").val();

        TransportAmount = $("#TransportBills").val() == '' ? 0 : $("#TransportBills").val();

        MobileAmount = $("#MobileBills").val() == '' ? 0 : $("#MobileBills").val();

        MiscellaneousAmount = $("#Miscellaneous").val() == '' ? 0 : $("#Miscellaneous").val();

        TotalAmount = parseInt(HotelAmount) +
                  parseInt(TravelAmount) +
                  parseInt(MealAmount) +
                  parseInt(LandLineAmount) +
                  parseInt(TransportAmount) +
                  parseInt(MobileAmount) +
                  parseInt(MiscellaneousAmount);

        if (TotalAmount == 0) {
            alert("Cannot Submit Empty Expense Form!");
            return false;
        }
        else if (checkFileuploads() === false)
        {
            $("#file").focus();
            alert("Upload Attachment");
            return false;
        }
        else
        {
            return true;
        }
    }
    else {
        return false;
    }
}

function checkFileuploads() {
    var file1 = $("#file").val();
    var file2 = $("#Singlefile").val();

    if (file1 === '' && file2 === '') {
        return false
    }
    else {
        return true;
    }
}
