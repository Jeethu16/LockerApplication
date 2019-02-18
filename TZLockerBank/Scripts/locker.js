$(document).ready(function () {

    var ddlLocation = $('#ddlLocation');
    ddlLocation.append($("<option></option>").val('').html('Please Select Location'));
    $.ajax({
        url: '/TZLocker/BindLocation',
        type: 'GET',
        dataType: 'json',
        success: function (d) {
            $.each(d, function (i, location) {
                ddlLocation.append($("<option></option>").val(location.Location_id).html(location.Location_Name));
            });
        },
        error: function () {
            alert('Error!');
        }
    });

    //Locker Bank details by location id  

    $("#ddlLocation").change(function () {
        var LocationId = parseInt($(this).val());

        if (!isNaN(LocationId)) {
            var ddlLockerBank = $('#ddlLockerBank');
            ddlLockerBank.empty();
            ddlLockerBank.append($("<option></option>").val('').html('Please wait ...'));

            debugger;
            $.ajax({
                url: '/TZLocker/BindLockerBank',
                type: 'GET',
                dataType: 'json',
                data: { LocationId: LocationId },
                success: function (d) {

                    ddlLockerBank.empty(); // Clear the please wait  
                    ddlLockerBank.append($("<option></option>").val('').html('Select Locker Bank'));
                    $.each(d, function (i, lockerbanks) {
                        ddlLockerBank.append($("<option></option>").val(lockerbanks.LockerBank_id).html(lockerbanks.LockerBank_Name));
                    });
                },
                error: function () {
                    alert('Error!');
                }
            });
        }


    });

    //Locker Bind By locker bank id  
    $("#ddlLockerBank").change(function () {
        var LockerBankId = parseInt($(this).val());
        if (!isNaN(LockerBankId)) {
            var ddlLocker = $('#ddlLocker');
            ddlLocker.append($("<option></option>").val('').html('Please wait ...'));

            debugger;
            $.ajax({
                url: '/TZLocker/BindLocker',
                type: 'GET',
                dataType: 'json',
                data: { lockerBankId: LockerBankId },
                success: function (d) {


                    ddlLocker.empty(); // Clear the plese wait  
                    ddlLocker.append($("<option></option>").val('').html('Select locker Name'));
                    $.each(d, function (i, lockers) {
                        ddlLocker.append($("<option></option>").val(lockers.Locker_id).html(lockers.LockerName));
                    });
                },
                error: function () {
                    alert('Error!');
                }
            });
        }


    });

    

});


