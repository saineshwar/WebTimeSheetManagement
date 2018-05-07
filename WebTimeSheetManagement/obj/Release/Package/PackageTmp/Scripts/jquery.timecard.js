$(document).ready(function () {
    $("#_panelmain").hide();
    DisableonLoad();
    $("#datepicker_start").datepicker(
    {
        dateFormat: "yy-mm-dd",
        changeMonth: true,
        changeYear: true,
        yearRange: new Date().getFullYear() + ':' + new Date().getFullYear(),
        onSelect: function (selectedDate) {
            CheckIsDateAlreadyUsed(selectedDate);

        },
        beforeShowDay: function (date) {
            return [date.getDay() === 0, ''];
        }
    });


});


function CalEnd() {

    var a = $("#datepicker_start").datepicker('getDate').getTime();

    var weekday = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
    var selectedFrom = $("#datepicker_start").val();
   

    var FromArray = selectedFrom.split('-');
  

    var newFromDate = new Date(FromArray[0], FromArray[1] - 1, FromArray[2]);
    var startDate = new Date(FromArray[0], FromArray[1] - 1, FromArray[2]);

    var DisplaystartDate = "";

    if (DisplaystartDate == "") {
        var data = newFromDate;
        $("#date1").text(data.getDate() + '-' + data.getFullYear());
        var hddate1 = data.getFullYear() + '-' + parseFloat(data.getMonth() + 1) + '-' + data.getDate();
        $("#hdtext1").val(hddate1);
        $("#label1").text('[' + weekday[data.getDay()] + ']');
        $("#DaysofWeek1").val(weekday[data.getDay()]);
    }

    for (var i = 0; i < 7; i++) {
        var tempdate = newFromDate;
        var labelDate = newFromDate.setDate(tempdate.getDate() + 1);

        if (i == 0) {
            $("#label2").text('[' + weekday[data.getDay()] + ']');
            $("#date2").text(data.getDate() + '-' + data.getFullYear());
            var hddate2 = data.getFullYear() + '-' + parseFloat(data.getMonth() + 1) + '-' + data.getDate();
            $("#hdtext2").val(hddate2);
            $("#DaysofWeek2").val(weekday[data.getDay()]);
        }
        else if (i == 1) {
            $("#label3").text('[' + weekday[data.getDay()] + ']');
            $("#date3").text(tempdate.getDate() + '-' + tempdate.getFullYear());
            var hddate3 = data.getFullYear() + '-' + parseFloat(data.getMonth() + 1) + '-' + data.getDate();
            $("#hdtext3").val(hddate3);
            $("#DaysofWeek3").val(weekday[data.getDay()]);
        }
        else if (i == 2) {
            $("#label4").text('[' + weekday[data.getDay()] + ']');
            $("#date4").text(tempdate.getDate() + '-' + tempdate.getFullYear());
            var hddate4 = data.getFullYear() + '-' + parseFloat(data.getMonth() + 1) + '-' + data.getDate();
            $("#hdtext4").val(hddate4);
            $("#DaysofWeek4").val(weekday[data.getDay()]);
        }
        else if (i == 3) {
            $("#label5").text('[' + weekday[data.getDay()] + ']');
            $("#date5").text(tempdate.getDate() + '-' + tempdate.getFullYear());
            var hddate5 = data.getFullYear() + '-' + parseFloat(data.getMonth() + 1) + '-' + data.getDate();
            $("#hdtext5").val(hddate5);
            $("#DaysofWeek5").val(weekday[data.getDay()]);
        }
        else if (i == 4) {
            $("#label6").text('[' + weekday[data.getDay()] + ']');
            $("#date6").text(tempdate.getDate() + '-' + tempdate.getFullYear());
            var hddate6 = data.getFullYear() + '-' + parseFloat(data.getMonth() + 1) + '-' + data.getDate();
            $("#hdtext6").val(hddate6);
            $("#DaysofWeek6").val(weekday[data.getDay()]);
        }
        else if (i == 5) {
            $("#label7").text('[' + weekday[data.getDay()] + ']');
            $("#date7").text(tempdate.getDate() + '-' + tempdate.getFullYear());
            var hddate7 = data.getFullYear() + '-' + parseFloat(data.getMonth() + 1) + '-' + data.getDate();
            $("#hdtext7").val(hddate7);
            $("#DaysofWeek7").val(weekday[data.getDay()]);
        }
    }
}

$("#datepicker_end").datepicker(
   {
       dateFormat: "yy-mm-dd",
       changeMonth: true,
       changeYear: true,
       yearRange: new Date().getFullYear() + ':' + new Date().getFullYear(),
       onSelect: function (dateText) {

           var a = $("#datepicker_start").datepicker('getDate').getTime();
           var weekday = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
           var diffDays = Math.round(Math.abs((a - b) / (c)));

           var selectedFrom = $("#datepicker_start").val();
           var selectedTo = $("#datepicker_end").val();

           var FromArray = selectedFrom.split('-');
           var ToArray = selectedTo.split('-');

           var newFromDate = new Date(FromArray[0], FromArray[1] - 1, FromArray[2]);

           var startDate = new Date(FromArray[0], FromArray[1] - 1, FromArray[2]);

           var newToDate = new Date(ToArray[0], ToArray[1] - 1, ToArray[2]);

           var DisplaystartDate = "";

           if (DisplaystartDate == "") {
               var data = newFromDate;
               $("#date1").val(data.getMonth() + 1 + '-' + data.getDate() + '-' + data.getFullYear() + ' ' + '[' + weekday[data.getDay()] + ']');
           }

           for (var i = 0; i < 7; i++) {

               var s = newFromDate;
               var labelDate = newFromDate.setDate(s.getDate() + 1);

               if (i == 0) {
                   $("#date2").val(data.getMonth() + 1 + '-' + data.getDate() + '-' + data.getFullYear() + ' ' + '[' + weekday[data.getDay()] + ']');
               }
               else if (i == 1) {
                   $("#date3").val(s.getMonth() + 1 + '-' + s.getDate() + '-' + s.getFullYear() + ' ' + '[' + weekday[s.getDay()] + ']');
               }
               else if (i == 2) {
                   $("#date4").val(s.getMonth() + 1 + '-' + s.getDate() + '-' + s.getFullYear() + ' ' + '[' + weekday[s.getDay()] + ']');
               }
               else if (i == 3) {
                   $("#date5").val(s.getMonth() + 1 + '-' + s.getDate() + '-' + s.getFullYear() + ' ' + '[' + weekday[s.getDay()] + ']');
               }
               else if (i == 4) {
                   $("#date6").val(s.getMonth() + 1 + '-' + s.getDate() + '-' + s.getFullYear() + ' ' + '[' + weekday[s.getDay()] + ']');
               }
               else if (i == 5) {
                   $("#date7").val(s.getMonth() + 1 + '-' + s.getDate() + '-' + s.getFullYear() + ' ' + '[' + weekday[s.getDay()] + ']');
               }

           }
       }
   });

function CheckIsDateAlreadyUsed(selectedDate) {
    var url = "/TimeSheet/CheckIsDateAlreadyUsed";

    $.ajax({
        url: url,
        type: 'POST',
        data: { FromDate: selectedDate },
        success: function (response) {
            if (response == true) {
                $("#text1").val('');
                $("#text2").val('');
                $("#text3").val('');
                $("#text4").val('');
                $("#text5").val('');
                $("#text6").val('');
                $("#text7").val('');
                $("#_panelmain").hide();
                alert("You have already filled Details for Choosen Date !");

            }
            else {
                var date2 = $('#datepicker_start').datepicker('getDate', '+1');
                CalEnd();
                $("#_panelmain").show();
            }
        }
    });
}


function ValidateData() {
    if (confirm('Please check data once before submitting ?'))
    {

        if (confirm(' Are you sure you want to save data?'))
    {
        if (ValidateTotalSundaysHours() > 24)
        {
            alert("A day cannot have more than 24 hours.");
            $("#text1_p1").focus();
            return false;
        }
        else if (ValidateTotalMondaysHours() > 24)
        {
            alert("A day cannot have more than 24 hours.");
            $("#text2_p1").focus();
            return false;
        }
        else if (ValidateTotalTuesdayHours() > 24)
        {
            alert("A day cannot have more than 24 hours.");
            $("#text3_p1").focus();
            return false;
        }
        else if (ValidateTotalWednesdayHours() > 24)
        {
            alert("A day cannot have more than 24 hours.");
            $("#text4_p1").focus();
            return false;
        }
        else if (ValidateTotalThursdayHours() > 24)
        {
            alert("A day cannot have more than 24 hours.");
            $("#text5_p1").focus();
            return false;
        }
        else if (ValidateTotalFridayHours() > 24)
        {
            alert("A day cannot have more than 24 hours.");
            $("#text6_p1").focus();
            return false;
        }
        else if (ValidateTotalSaturdayHours() > 24)
        {
            alert("A day cannot have more than 24 hours.");
            $("#text7_p1").focus();
            return false;
        }

        return true;
    }
    else
    {
        return false;
    }


    }
}

function DisableonLoad() {

    $("#text1_p1").prop('readonly', true);
    $("#text2_p1").prop('readonly', true);
    $("#text3_p1").prop('readonly', true);
    $("#text4_p1").prop('readonly', true);
    $("#text5_p1").prop('readonly', true);
    $("#text6_p1").prop('readonly', true);
    $("#text7_p1").prop('readonly', true);


    $("#text1_p2").prop('readonly', true);
    $("#text2_p2").prop('readonly', true);
    $("#text3_p2").prop('readonly', true);
    $("#text4_p2").prop('readonly', true);
    $("#text5_p2").prop('readonly', true);
    $("#text6_p2").prop('readonly', true);
    $("#text7_p2").prop('readonly', true);

    $("#text1_p3").prop('readonly', true);
    $("#text2_p3").prop('readonly', true);
    $("#text3_p3").prop('readonly', true);
    $("#text4_p3").prop('readonly', true);
    $("#text5_p3").prop('readonly', true);
    $("#text6_p3").prop('readonly', true);
    $("#text7_p3").prop('readonly', true);

    $("#text1_p4").prop('readonly', true);
    $("#text2_p4").prop('readonly', true);
    $("#text3_p4").prop('readonly', true);
    $("#text4_p4").prop('readonly', true);
    $("#text5_p4").prop('readonly', true);
    $("#text6_p4").prop('readonly', true);
    $("#text7_p4").prop('readonly', true);

    $("#text1_p5").prop('readonly', true);
    $("#text2_p5").prop('readonly', true);
    $("#text3_p5").prop('readonly', true);
    $("#text4_p5").prop('readonly', true);
    $("#text5_p5").prop('readonly', true);
    $("#text6_p5").prop('readonly', true);
    $("#text7_p5").prop('readonly', true);

    $("#text1_p6").prop('readonly', true);
    $("#text2_p6").prop('readonly', true);
    $("#text3_p6").prop('readonly', true);
    $("#text4_p6").prop('readonly', true);
    $("#text5_p6").prop('readonly', true);
    $("#text6_p6").prop('readonly', true);
    $("#text7_p6").prop('readonly', true);

    $("#ProjectID2").attr('disabled', true);
    $("#ProjectID3").attr('disabled', true);
    $("#ProjectID4").attr('disabled', true);
    $("#ProjectID5").attr('disabled', true);
    $("#ProjectID6").attr('disabled', true);



}

$(document).ready(function () {
    $("#ProjectID1").change(function () {
        if ($("#ProjectID1").val() != '')
        {
            $("#text1_p1").prop('readonly', false);
            $("#text2_p1").prop('readonly', false);
            $("#text3_p1").prop('readonly', false);
            $("#text4_p1").prop('readonly', false);
            $("#text5_p1").prop('readonly', false);
            $("#text6_p1").prop('readonly', false);
            $("#text7_p1").prop('readonly', false);
            $("#ProjectID2").attr('disabled', false);
        }
        else {

            $("#text1_p1").prop('readonly', true);
            $("#text2_p1").prop('readonly', true);
            $("#text3_p1").prop('readonly', true);
            $("#text4_p1").prop('readonly', true);
            $("#text5_p1").prop('readonly', true);
            $("#text6_p1").prop('readonly', true);
            $("#text7_p1").prop('readonly', true);

            $("#text1_p1").val('');
            $("#text2_p1").val('');
            $("#text3_p1").val('');
            $("#text4_p1").val('');
            $("#text5_p1").val('');
            $("#text6_p1").val('');
            $("#text7_p1").val('');

            $("#ProjectID2").attr('disabled', true);
        }

    });

    $("#ProjectID2").change(function () {

        var ddlProject1 = $("#ProjectID1").val();

        if (ddlProject1 == $("#ProjectID2").val()) {
            $("#ProjectID2").val('');
            alert("Cannot Choose Same Project");
        }
        else {
            if ($("#ProjectID2").val() != '') {
                $("#text1_p2").prop('readonly', false);
                $("#text2_p2").prop('readonly', false);
                $("#text3_p2").prop('readonly', false);
                $("#text4_p2").prop('readonly', false);
                $("#text5_p2").prop('readonly', false);
                $("#text6_p2").prop('readonly', false);
                $("#text7_p2").prop('readonly', false);
                $("#ProjectID3").attr('disabled', false);
            }
            else {

                $("#text1_p2").prop('readonly', true);
                $("#text2_p2").prop('readonly', true);
                $("#text3_p2").prop('readonly', true);
                $("#text4_p2").prop('readonly', true);
                $("#text5_p2").prop('readonly', true);
                $("#text6_p2").prop('readonly', true);
                $("#text7_p2").prop('readonly', true);

                $("#text1_p2").val('');
                $("#text2_p2").val('');
                $("#text3_p2").val('');
                $("#text4_p2").val('');
                $("#text5_p2").val('');
                $("#text6_p2").val('');
                $("#text7_p2").val('');
                $("#ProjectID3").attr('disabled', true);
            }
        }

    });

    $("#ProjectID3").change(function () {
        var ddlProject1 = $("#ProjectID1").val();
        var ddlProject2 = $("#ProjectID2").val();

        if (ddlProject1 == $("#ProjectID3").val() || ddlProject2 == $("#ProjectID3").val()) {
            $("#ProjectID3").val('');
            alert("Cannot Choose Same Project");
        }
        else {
            if ($("#ProjectID3").val() != '') {
                $("#text1_p3").prop('readonly', false);
                $("#text2_p3").prop('readonly', false);
                $("#text3_p3").prop('readonly', false);
                $("#text4_p3").prop('readonly', false);
                $("#text5_p3").prop('readonly', false);
                $("#text6_p3").prop('readonly', false);
                $("#text7_p3").prop('readonly', false);
                $("#ProjectID4").attr('disabled', false);
            }
            else {
                $("#ProjectID4").attr('disabled', true);
                $("#text1_p3").prop('readonly', true);
                $("#text2_p3").prop('readonly', true);
                $("#text3_p3").prop('readonly', true);
                $("#text4_p3").prop('readonly', true);
                $("#text5_p3").prop('readonly', true);
                $("#text6_p3").prop('readonly', true);
                $("#text7_p3").prop('readonly', true);

                $("#text1_p3").val('');
                $("#text2_p3").val('');
                $("#text3_p3").val('');
                $("#text4_p3").val('');
                $("#text5_p3").val('');
                $("#text6_p3").val('');
                $("#text7_p3").val('');


            }
        }

    });

    $("#ProjectID4").change(function () {
        var ddlProject1 = $("#ProjectID1").val();
        var ddlProject2 = $("#ProjectID2").val();
        var ddlProject3 = $("#ProjectID3").val();

        if (ddlProject1 == $("#ProjectID4").val() || ddlProject2 == $("#ProjectID4").val() || ddlProject3 == $("#ProjectID4").val()) {
            $("#ProjectID4").val('');
            alert("Cannot Choose Same Project");
        }
        else {

            if ($("#ProjectID4").val() != '') {
                $("#text1_p4").prop('readonly', false);
                $("#text2_p4").prop('readonly', false);
                $("#text3_p4").prop('readonly', false);
                $("#text4_p4").prop('readonly', false);
                $("#text5_p4").prop('readonly', false);
                $("#text6_p4").prop('readonly', false);
                $("#text7_p4").prop('readonly', false);
                $("#ProjectID5").attr('disabled', false);
            }
            else {

                $("#text1_p4").prop('readonly', true);
                $("#text2_p4").prop('readonly', true);
                $("#text3_p4").prop('readonly', true);
                $("#text4_p4").prop('readonly', true);
                $("#text5_p4").prop('readonly', true);
                $("#text6_p4").prop('readonly', true);
                $("#text7_p4").prop('readonly', true);

                $("#text1_p4").val('');
                $("#text2_p4").val('');
                $("#text3_p4").val('');
                $("#text4_p4").val('');
                $("#text5_p4").val('');
                $("#text6_p4").val('');
                $("#text7_p4").val('');
                $("#ProjectID5").attr('disabled', true);
            }
        }
    });

    $("#ProjectID5").change(function () {

        var ddlProject1 = $("#ProjectID1").val();
        var ddlProject2 = $("#ProjectID2").val();
        var ddlProject3 = $("#ProjectID3").val();
        var ddlProject4 = $("#ProjectID4").val();

        if (ddlProject1 == $("#ProjectID5").val() || ddlProject2 == $("#ProjectID5").val() || ddlProject3 == $("#ProjectID5").val() || ddlProject4 == $("#ProjectID5").val()) {
            $("#ProjectID5").val('');
            alert("Cannot Choose Same Project");
        }
        else {

            if ($("#ProjectID4").val() != '') {
                $("#text1_p5").prop('readonly', false);
                $("#text2_p5").prop('readonly', false);
                $("#text3_p5").prop('readonly', false);
                $("#text4_p5").prop('readonly', false);
                $("#text5_p5").prop('readonly', false);
                $("#text6_p5").prop('readonly', false);
                $("#text7_p5").prop('readonly', false);
                $("#ProjectID6").attr('disabled', false);
            }
            else {

                $("#text1_p5").prop('readonly', true);
                $("#text2_p5").prop('readonly', true);
                $("#text3_p5").prop('readonly', true);
                $("#text4_p5").prop('readonly', true);
                $("#text5_p5").prop('readonly', true);
                $("#text6_p5").prop('readonly', true);
                $("#text7_p5").prop('readonly', true);

                $("#text1_p5").val('');
                $("#text2_p5").val('');
                $("#text3_p5").val('');
                $("#text4_p5").val('');
                $("#text5_p5").val('');
                $("#text6_p5").val('');
                $("#text7_p5").val('');
                $("#ProjectID6").attr('disabled', true);
            }
        }

    });

    $("#ProjectID6").change(function () {

        var ddlProject1 = $("#ProjectID1").val();
        var ddlProject2 = $("#ProjectID2").val();
        var ddlProject3 = $("#ProjectID3").val();
        var ddlProject4 = $("#ProjectID4").val();
        var ddlProject5 = $("#ProjectID5").val();

        if (ddlProject1 == $("#ProjectID6").val() || ddlProject2 == $("#ProjectID6").val() || ddlProject3 == $("#ProjectID6").val() || ddlProject4 == $("#ProjectID6").val() || ddlProject5 == $("#ProjectID6").val()) {
            $("#ProjectID6").val('');
            alert("Cannot Choose Same Project");
        }
        else {

            if ($("#ProjectID4").val() != '') {
                $("#text1_p6").prop('readonly', false);
                $("#text2_p6").prop('readonly', false);
                $("#text3_p6").prop('readonly', false);
                $("#text4_p6").prop('readonly', false);
                $("#text5_p6").prop('readonly', false);
                $("#text6_p6").prop('readonly', false);
                $("#text7_p6").prop('readonly', false);
            }
            else {

                $("#text1_p6").prop('readonly', true);
                $("#text2_p6").prop('readonly', true);
                $("#text3_p6").prop('readonly', true);
                $("#text4_p6").prop('readonly', true);
                $("#text5_p6").prop('readonly', true);
                $("#text6_p6").prop('readonly', true);
                $("#text7_p6").prop('readonly', true);

                $("#text1_p6").val('');
                $("#text2_p6").val('');
                $("#text3_p6").val('');
                $("#text4_p6").val('');
                $("#text5_p6").val('');
                $("#text6_p6").val('');
                $("#text7_p6").val('');
            }
        }

    });
});

function TotalP1() {
    var text1_p1 = 0;
    var text2_p1 = 0;
    var text3_p1 = 0;
    var text4_p1 = 0;
    var text5_p1 = 0;
    var text6_p1 = 0;
    var text7_p1 = 0;
    var TotalAmount = 0;

    text1_p1 = $("#text1_p1").val() == '' ? 0 : $("#text1_p1").val();
    text2_p1 = $("#text2_p1").val() == '' ? 0 : $("#text2_p1").val();
    text3_p1 = $("#text3_p1").val() == '' ? 0 : $("#text3_p1").val();
    text4_p1 = $("#text4_p1").val() == '' ? 0 : $("#text4_p1").val();
    text5_p1 = $("#text5_p1").val() == '' ? 0 : $("#text5_p1").val();
    text6_p1 = $("#text6_p1").val() == '' ? 0 : $("#text6_p1").val();
    text7_p1 = $("#text7_p1").val() == '' ? 0 : $("#text7_p1").val();

    TotalAmount =
              parseInt(text1_p1) +
              parseInt(text2_p1) +
              parseInt(text3_p1) +
              parseInt(text4_p1) +
              parseInt(text5_p1) +
              parseInt(text6_p1) +
              parseInt(text7_p1);

    $("#texttotal_p1").val(TotalAmount);

}

function TotalP2() {
    var text1_p2 = 0;
    var text2_p2 = 0;
    var text3_p2 = 0;
    var text4_p2 = 0;
    var text5_p2 = 0;
    var text6_p2 = 0;
    var text7_p2 = 0;
    var TotalAmount = 0;

    text1_p2 = $("#text1_p2").val() == '' ? 0 : $("#text1_p2").val();
    text2_p2 = $("#text2_p2").val() == '' ? 0 : $("#text2_p2").val();
    text3_p2 = $("#text3_p2").val() == '' ? 0 : $("#text3_p2").val();
    text4_p2 = $("#text4_p2").val() == '' ? 0 : $("#text4_p2").val();
    text5_p2 = $("#text5_p2").val() == '' ? 0 : $("#text5_p2").val();
    text6_p2 = $("#text6_p2").val() == '' ? 0 : $("#text6_p2").val();
    text7_p2 = $("#text7_p2").val() == '' ? 0 : $("#text7_p2").val();

    TotalAmount =
              parseInt(text1_p2) +
              parseInt(text2_p2) +
              parseInt(text3_p2) +
              parseInt(text4_p2) +
              parseInt(text5_p2) +
              parseInt(text6_p2) +
              parseInt(text7_p2);

    $("#texttotal_p2").val(TotalAmount);

}

function TotalP3() {
    var text1_p3 = 0;
    var text2_p3 = 0;
    var text3_p3 = 0;
    var text4_p3 = 0;
    var text5_p3 = 0;
    var text6_p3 = 0;
    var text7_p3 = 0;
    var TotalAmount = 0;

    text1_p3 = $("#text1_p3").val() == '' ? 0 : $("#text1_p3").val();
    text2_p3 = $("#text2_p3").val() == '' ? 0 : $("#text2_p3").val();
    text3_p3 = $("#text3_p3").val() == '' ? 0 : $("#text3_p3").val();
    text4_p3 = $("#text4_p3").val() == '' ? 0 : $("#text4_p3").val();
    text5_p3 = $("#text5_p3").val() == '' ? 0 : $("#text5_p3").val();
    text6_p3 = $("#text6_p3").val() == '' ? 0 : $("#text6_p3").val();
    text7_p3 = $("#text7_p3").val() == '' ? 0 : $("#text7_p3").val();

    TotalAmount =
              parseInt(text1_p3) +
              parseInt(text2_p3) +
              parseInt(text3_p3) +
              parseInt(text4_p3) +
              parseInt(text5_p3) +
              parseInt(text6_p3) +
              parseInt(text7_p3);

    $("#texttotal_p3").val(TotalAmount);

}

function TotalP4() {
    var text1_p4 = 0;
    var text2_p4 = 0;
    var text3_p4 = 0;
    var text4_p4 = 0;
    var text5_p4 = 0;
    var text6_p4 = 0;
    var text7_p4 = 0;
    var TotalAmount = 0;

    text1_p4 = $("#text1_p4").val() == '' ? 0 : $("#text1_p4").val();
    text2_p4 = $("#text2_p4").val() == '' ? 0 : $("#text2_p4").val();
    text3_p4 = $("#text3_p4").val() == '' ? 0 : $("#text3_p4").val();
    text4_p4 = $("#text4_p4").val() == '' ? 0 : $("#text4_p4").val();
    text5_p4 = $("#text5_p4").val() == '' ? 0 : $("#text5_p4").val();
    text6_p4 = $("#text6_p4").val() == '' ? 0 : $("#text6_p4").val();
    text7_p4 = $("#text7_p4").val() == '' ? 0 : $("#text7_p4").val();

    TotalAmount =
              parseInt(text1_p4) +
              parseInt(text2_p4) +
              parseInt(text3_p4) +
              parseInt(text4_p4) +
              parseInt(text5_p4) +
              parseInt(text6_p4) +
              parseInt(text7_p4);

    $("#texttotal_p4").val(TotalAmount);

}

function TotalP5() {
    var text1_p5 = 0;
    var text2_p5 = 0;
    var text3_p5 = 0;
    var text4_p5 = 0;
    var text5_p5 = 0;
    var text6_p5 = 0;
    var text7_p5 = 0;
    var TotalAmount = 0;

    text1_p5 = $("#text1_p5").val() == '' ? 0 : $("#text1_p5").val();
    text2_p5 = $("#text2_p5").val() == '' ? 0 : $("#text2_p5").val();
    text3_p5 = $("#text3_p5").val() == '' ? 0 : $("#text3_p5").val();
    text4_p5 = $("#text4_p5").val() == '' ? 0 : $("#text4_p5").val();
    text5_p5 = $("#text5_p5").val() == '' ? 0 : $("#text5_p5").val();
    text6_p5 = $("#text6_p5").val() == '' ? 0 : $("#text6_p5").val();
    text7_p5 = $("#text7_p5").val() == '' ? 0 : $("#text7_p5").val();

    TotalAmount =
              parseInt(text1_p5) +
              parseInt(text2_p5) +
              parseInt(text3_p5) +
              parseInt(text4_p5) +
              parseInt(text5_p5) +
              parseInt(text6_p5) +
              parseInt(text7_p5);

    $("#texttotal_p5").val(TotalAmount);

}

function TotalP6() {
    var text1_p6 = 0;
    var text2_p6 = 0;
    var text3_p6 = 0;
    var text4_p6 = 0;
    var text5_p6 = 0;
    var text6_p6 = 0;
    var text7_p6 = 0;
    var TotalAmount = 0;

    text1_p6 = $("#text1_p6").val() == '' ? 0 : $("#text1_p6").val();
    text2_p6 = $("#text2_p6").val() == '' ? 0 : $("#text2_p6").val();
    text3_p6 = $("#text3_p6").val() == '' ? 0 : $("#text3_p6").val();
    text4_p6 = $("#text4_p6").val() == '' ? 0 : $("#text4_p6").val();
    text5_p6 = $("#text5_p6").val() == '' ? 0 : $("#text5_p6").val();
    text6_p6 = $("#text6_p6").val() == '' ? 0 : $("#text6_p6").val();
    text7_p6 = $("#text7_p6").val() == '' ? 0 : $("#text7_p6").val();

    TotalAmount =
              parseInt(text1_p6) +
              parseInt(text2_p6) +
              parseInt(text3_p6) +
              parseInt(text4_p6) +
              parseInt(text5_p6) +
              parseInt(text6_p6) +
              parseInt(text7_p6);

    $("#texttotal_p6").val(TotalAmount);

}


function ValidateTotalSundaysHours()
{
    var text1_p1 = 0;
    var text1_p2 = 0;
    var text1_p3 = 0;
    var text1_p4 = 0;
    var text1_p5 = 0;
    var text1_p6 = 0;
    var TotalHours = 0;

    text1_p1 = $("#text1_p1").val() == '' ? 0 : $("#text1_p1").val();
    text1_p2 = $("#text1_p2").val() == '' ? 0 : $("#text1_p2").val();
    text1_p3 = $("#text1_p3").val() == '' ? 0 : $("#text1_p3").val();
    text1_p4 = $("#text1_p4").val() == '' ? 0 : $("#text1_p4").val();
    text1_p5 = $("#text1_p5").val() == '' ? 0 : $("#text1_p5").val();
    text1_p6 = $("#text1_p6").val() == '' ? 0 : $("#text1_p6").val();

    TotalHours = parseInt(text1_p1) +
              parseInt(text1_p2) +
              parseInt(text1_p3) +
              parseInt(text1_p4) +
              parseInt(text1_p5) +
              parseInt(text1_p6);

    return TotalHours;
}

function ValidateTotalMondaysHours()
{
    var text2_p1 = 0;
    var text2_p2 = 0;
    var text2_p3 = 0;
    var text2_p4 = 0;
    var text2_p5 = 0;
    var text2_p6 = 0;
    var TotalHours = 0;

    text2_p1 = $("#text2_p1").val() == '' ? 0 : $("#text2_p1").val();
    text2_p2 = $("#text2_p2").val() == '' ? 0 : $("#text2_p2").val();
    text2_p3 = $("#text2_p3").val() == '' ? 0 : $("#text2_p3").val();
    text2_p4 = $("#text2_p4").val() == '' ? 0 : $("#text2_p4").val();
    text2_p5 = $("#text2_p5").val() == '' ? 0 : $("#text2_p5").val();
    text2_p6 = $("#text2_p6").val() == '' ? 0 : $("#text2_p6").val();
                       2
    TotalHours = parseInt(text2_p1) +
                 parseInt(text2_p2) +
                 parseInt(text2_p3) +
                 parseInt(text2_p4) +
                 parseInt(text2_p5) +
                 parseInt(text2_p6);

    return TotalHours;
}

function ValidateTotalTuesdayHours()
{
    var text3_p1 = 0;
    var text3_p2 = 0;
    var text3_p3 = 0;
    var text3_p4 = 0;
    var text3_p5 = 0;
    var text3_p6 = 0;
    var TotalHours = 0;

    text3_p1 = $("#text3_p1").val() == '' ? 0 : $("#text3_p1").val();
    text3_p2 = $("#text3_p2").val() == '' ? 0 : $("#text3_p2").val();
    text3_p3 = $("#text3_p3").val() == '' ? 0 : $("#text3_p3").val();
    text3_p4 = $("#text3_p4").val() == '' ? 0 : $("#text3_p4").val();
    text3_p5 = $("#text3_p5").val() == '' ? 0 : $("#text3_p5").val();
    text3_p6 = $("#text3_p6").val() == '' ? 0 : $("#text3_p6").val();
    
    TotalHours = parseInt(text3_p1) +
                 parseInt(text3_p2) +
                 parseInt(text3_p3) +
                 parseInt(text3_p4) +
                 parseInt(text3_p5) +
                 parseInt(text3_p6);

    return TotalHours;
}

function ValidateTotalWednesdayHours()
{
    var text4_p1 = 0;
    var text4_p2 = 0;
    var text4_p3 = 0;
    var text4_p4 = 0;
    var text4_p5 = 0;
    var text4_p6 = 0;
    var TotalHours = 0;

    text4_p1 = $("#text4_p1").val() == '' ? 0 : $("#text4_p1").val();
    text4_p2 = $("#text4_p2").val() == '' ? 0 : $("#text4_p2").val();
    text4_p3 = $("#text4_p3").val() == '' ? 0 : $("#text4_p3").val();
    text4_p4 = $("#text4_p4").val() == '' ? 0 : $("#text4_p4").val();
    text4_p5 = $("#text4_p5").val() == '' ? 0 : $("#text4_p5").val();
    text4_p6 = $("#text4_p6").val() == '' ? 0 : $("#text4_p6").val();

    TotalHours = parseInt(text4_p1) +
                 parseInt(text4_p2) +
                 parseInt(text4_p3) +
                 parseInt(text4_p4) +
                 parseInt(text4_p5) +
                 parseInt(text4_p6);

    return TotalHours;
}

function ValidateTotalThursdayHours()
{
    var text5_p1 = 0;
    var text5_p2 = 0;
    var text5_p3 = 0;
    var text5_p4 = 0;
    var text5_p5 = 0;
    var text5_p6 = 0;
    var TotalHours = 0;

    text5_p1 = $("#text5_p1").val() == '' ? 0 : $("#text5_p1").val();
    text5_p2 = $("#text5_p2").val() == '' ? 0 : $("#text5_p2").val();
    text5_p3 = $("#text5_p3").val() == '' ? 0 : $("#text5_p3").val();
    text5_p4 = $("#text5_p4").val() == '' ? 0 : $("#text5_p4").val();
    text5_p5 = $("#text5_p5").val() == '' ? 0 : $("#text5_p5").val();
    text5_p6 = $("#text5_p6").val() == '' ? 0 : $("#text5_p6").val();

    TotalHours = parseInt(text5_p1) +
                 parseInt(text5_p2) +
                 parseInt(text5_p3) +
                 parseInt(text5_p4) +
                 parseInt(text5_p5) +
                 parseInt(text5_p6);

    return TotalHours;
}

function ValidateTotalFridayHours()
{
    var text6_p1 = 0;
    var text6_p2 = 0;
    var text6_p3 = 0;
    var text6_p4 = 0;
    var text6_p5 = 0;
    var text6_p6 = 0;
    var TotalHours = 0;

    text6_p1 = $("#text6_p1").val() == '' ? 0 : $("#text6_p1").val();
    text6_p2 = $("#text6_p2").val() == '' ? 0 : $("#text6_p2").val();
    text6_p3 = $("#text6_p3").val() == '' ? 0 : $("#text6_p3").val();
    text6_p4 = $("#text6_p4").val() == '' ? 0 : $("#text6_p4").val();
    text6_p5 = $("#text6_p5").val() == '' ? 0 : $("#text6_p5").val();
    text6_p6 = $("#text6_p6").val() == '' ? 0 : $("#text6_p6").val();

    TotalHours = parseInt(text6_p1) +
                 parseInt(text6_p2) +
                 parseInt(text6_p3) +
                 parseInt(text6_p4) +
                 parseInt(text6_p5) +
                 parseInt(text6_p6);

    return TotalHours;
}

function ValidateTotalSaturdayHours() {
    var text7_p1 = 0;
    var text7_p2 = 0;
    var text7_p3 = 0;
    var text7_p4 = 0;
    var text7_p5 = 0;
    var text7_p6 = 0;
    var TotalHours = 0;

    text7_p1 = $("#text7_p1").val() == '' ? 0 : $("#text7_p1").val();
    text7_p2 = $("#text7_p2").val() == '' ? 0 : $("#text7_p2").val();
    text7_p3 = $("#text7_p3").val() == '' ? 0 : $("#text7_p3").val();
    text7_p4 = $("#text7_p4").val() == '' ? 0 : $("#text7_p4").val();
    text7_p5 = $("#text7_p5").val() == '' ? 0 : $("#text7_p5").val();
    text7_p6 = $("#text7_p6").val() == '' ? 0 : $("#text7_p6").val();

    TotalHours = parseInt(text7_p1) +
                 parseInt(text7_p2) +
                 parseInt(text7_p3) +
                 parseInt(text7_p4) +
                 parseInt(text7_p5) +
                 parseInt(text7_p6);

    return TotalHours;
}

function ValidateBlankSubmission()
{

}