
    $(function () {

        $('#categoryDropDownList').on("change", function (evt) {
            $("#txtQuantity").val("");
            $("#txtAmount").val("");
            $("#txtHours").val("");
            $("#txtKm").val("");

            $("#HoursDiv").css("visibility", "hidden")
            $("#HoursDiv").css("display", "none")

            $("#KmDiv").css("visibility", "hidden")
            $("#KmDiv").css("display", "none")

            var ReceiptTypeID = $('#categoryDropDownList').val();
            var obj = { ReceiptTypeID: ReceiptTypeID };

            //Invoice
            if (ReceiptTypeID == 6 || ReceiptTypeID == 40 ) {
                $("#QuantityDiv").css("visibility", "hidden")
                $("#QuantityDiv").css("display", "none")

                $("#AdditionalInfoDiv").css("visibility", "visible")
                $("#AdditionalInfoDiv").css("display", "")

                $("#lblAdditionalInfo").text("Invoice Number");
                $("#lblSecondColumn").text("Invoice Number");

                $("#CustomerIDDiv").css("visibility", "visible")
                $("#CustomerIDDiv").css("display", "")

                $("#CustomerDiv").css("visibility", "visible")
                $("#CustomerDiv").css("display", "")
            }

            else if (ReceiptTypeID == 3)
            {
                $("#QuantityDiv").css("visibility", "hidden")
                $("#QuantityDiv").css("display", "none")

                $("#AdditionalInfoDiv").css("visibility", "visible")
                $("#AdditionalInfoDiv").css("display", "")

                $("#lblAdditionalInfo").text("Additional Info");
                $("#lblSecondColumn").text("Additonal Info");
            }
            else {
                $("#QuantityDiv").css("visibility", "visible")
                $("#QuantityDiv").css("display", "")

                $("#AdditionalInfoDiv").css("visibility", "hidden")
                $("#AdditionalInfoDiv").css("display", "none")


                $("#CustomerIDDiv").css("visibility", "hidden")
                $("#CustomerIDDiv").css("display", "none")

                $("#CustomerDiv").css("visibility", "hidden")
                $("#CustomerDiv").css("display", "none")
            }

            //if (true) {

            //}

            //else {

            //}
      
            AjaxCall('/Receipts/GetServices', JSON.stringify(obj), 'POST').done(function (response) {
                if (response.length > 0) {
                    $('#serviceDropDownList').html('');
                    var options = '';
                    options += '<option value="Select">Select</option>';
                    for (var i = 0; i < response.length; i++) {
                        options += '<option value="' + response[i].ServiceID + '">' + JSON.stringify(response[i].Description) + '</option>';

                    }

                    $('#serviceDropDownList').html(options);

                    //Asset Disposal
                    if (ReceiptTypeID == 3) {
                        $('#serviceDropDownList').val(15);
                    }

                    //Invoice 
                    if (ReceiptTypeID == 6) {
                        $('#serviceDropDownList').val(26);
                    }

                    //Wrecker Service
                    if (ReceiptTypeID == 37) {
                        $('#serviceDropDownList').val(158);
                    }

                }
            }).fail(function (error) {
                alert(error.StatusText);
            });
        });

        //evt.stopImmediatePropagation();
    });

    function AjaxCall(url, data, type) {
        return $.ajax({
        url: url,
            type: type ? type : 'GET',
            data: data,
            contentType: 'application/json'
        });
}


var services = new Array();

function SupplyServiceId() {
    var serviceID = $('#serviceDropDownList').val();
    services.push(serviceID);

}

var amounts = new Array();

function SupplyServiceAmount() {
    var amount = $('#txtAmount').val();
    amounts.push(amount);


}

var quantitites = new Array();

function SupplyQuantity() {
    var quantity = $('#txtQuantity').val();
    quantitites.push(quantity);

}

var AdditionalInformations = new Array();

function SupplyAdditionalInformation() {
    var addInformation = $('#AdditionalInfo').val();
    AdditionalInformations.push(addInformation);

}


function PushServiceId() {
        $.ajax(
        {
            type: "POST",
            url: "/receipts/PushServiceId",
            data: JSON.stringify(services),
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }
    );
}

function CustomAdd() {

    SupplyServiceAmount();
    SupplyServiceId();
    SupplyQuantity();
    SupplyAdditionalInformation();
    //ClearBoxes();    
}


function CustomSubmit() {
    $.ajax(
        {
            type: "POST",
            url: "/receipts/PushServiceId",
            data: JSON.stringify(services),
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }
    );

    $.ajax(
        {
            type: "POST",
            url: "/receipts/PushAmount",
            data: JSON.stringify(amounts),
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }
    );
    $.ajax(
        {
            type: "POST",
            url: "/receipts/PushQuantities",
            data: JSON.stringify(quantitites),
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }

    );
    $.ajax(
        {
            type: "POST",
            url: "/receipts/PushAdditionalInfo",
            data: JSON.stringify(AdditionalInformations),
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }

    );
}

//var serviceID = $('#serviceDropDownList').val()

function GetAmountForService() {

    var serviceID = $('#serviceDropDownList').val();
    $("#txtQuantity").val("");
    $("#txtAmount").val("");

    var obj = { ServiceID: serviceID };

    AjaxCall('/Receipts/GetAmountForService', JSON.stringify(obj), 'POST').done(function (response) {
        if (response.length > 0) {
            for (var i = 0; i < response.length; i++) {
                var cost = response[i].Cost
                $("#txtAmount").val(cost);
                $("#txtQuantity").val("1");
            }
        }


    }).fail(function (error) {
        alert(error.StatusText);
    });

    function AjaxCall(url, data, type) {
        return $.ajax({
            url: url,
            type: type ? type : 'GET',
            data: data,
            contentType: 'application/json'

        });
    }

}

$('#serviceDropDownList').on("change", function (evt) {
    var serviceID = $('#serviceDropDownList').val();
    $("#txtQuantity").val("");
    $("#txtAmount").val("");
    $("#txtHours").val("");
    $("#txtKm").val("");

    var ReceiptTypeID = $('#categoryDropDownList').val();



   



    //else {

    //    $("#HoursDiv").css("visibility", "hidden")
    //    $("#HoursDiv").css("display", "none")

    //    $("#KmDiv").css("visibility", "hidden")
    //    $("#KmDiv").css("display", "none")

    //}

    var obj = { ServiceID: serviceID };

    //As long as we arent dealing with Invoices or Asset Disposal 
    if (serviceID != 26 || serviceID != 15) {

        AjaxCall('/Receipts/GetAmountForService', JSON.stringify(obj), 'POST').done(function (response) {
            if (response.length > 0) {
                for (var i = 0; i < response.length; i++) {
                    var cost = response[i].Cost
                    $("#txtAmount").val(cost);
                    $("#txtQuantity").val("1");
                }
            }


        }).fail(function (error) {
            alert(error.StatusText);
        });

        function AjaxCall(url, data, type) {
            return $.ajax({
                url: url,
                type: type ? type : 'GET',
                data: data,
                contentType: 'application/json'

            });
        }

    }

    if (serviceID == 1 || serviceID == 3 ) {
        $("#QuantityDiv").css("visibility", "hidden");
        $("#QuantityDiv").css("display", "none");
        $("#txtQuantity").val("10");

    }

    else if (serviceID == 16 || serviceID == 18) {

        $("#HoursDiv").css("visibility", "visible")
        $("#HoursDiv").css("display", "")

        $("#KmDiv").css("visibility", "hidden")
        $("#KmDiv").css("display", "none")
    }

    else if (serviceID == 188) {
        $("#KmDiv").css("visibility", "visible")
        $("#KmDiv").css("display", "")

        $("#HoursDiv").css("visibility", "hidden")
        $("#HoursDiv").css("display", "none")

    }

    else if (serviceID == 26 || serviceID == 15 ) {
        $("#QuantityDiv").css("visibility", "hidden");
        $("#QuantityDiv").css("display", "none");

    }
    else if (serviceID == 189 || serviceID == 191) {

        $("#lblAdditionalInfo").text("Invoice Number");
        //$("#lblSecondColumn").text("Invoice Number");

        $("#AdditionalInfoDiv").css("visibility", "visible")
        $("#AdditionalInfoDiv").css("display", "")

        $("#KmDiv").css("visibility", "hidden")
        $("#KmDiv").css("display", "none")

        $("#HoursDiv").css("visibility", "hidden")
        $("#HoursDiv").css("display", "none")

        $("#QuantityDiv").css("visibility", "hidden")
        $("#QuantityDiv").css("display", "none")

    }

    else {
        $("#QuantityDiv").css("visibility", "visible")
        $("#QuantityDiv").css("display", "")
        $("#txtQuantity").val("");

        $("#HoursDiv").css("visibility", "hidden")
        $("#HoursDiv").css("display", "none")

        $("#KmDiv").css("visibility", "hidden")
        $("#KmDiv").css("display", "none")
    }

    evt.stopImmediatePropagation();
});


$('#paymentTypeDropDownList').on("change", function (evt) {
    var paymentTypeID = $('#paymentTypeDropDownList').val();
    $("#txtLastFourDigits").val("");
    $("#txtChequeNumber").val("");

    if (paymentTypeID == 2 || paymentTypeID == 3 || paymentTypeID == 4 || paymentTypeID == 13) {
        $("#LastFourDigitsDiv").css("visibility", "visible");
        $("#LastFourDigitsDiv").css("display", "")
        $("#ChequeNumberDiv").css("visibility", "hidden");
        $("#ChequeNumberDiv").css("display", "none");

    }

    else if (paymentTypeID == 7 || paymentTypeID == 8 )
    {
        $("#ChequeNumberDiv").css("visibility", "visible");
        $("#ChequeNumberDiv").css("display", "")
        $("#LastFourDigitsDiv").css("visibility", "hidden");
        $("#LastFourDigitsDiv").css("display", "none");

    }

    else {

        $("#LastFourDigitsDiv").css("visibility", "hidden");
        $("#ChequeNumberDiv").css("visibility", "hidden");
        $("#LastFourDigitsDiv").css("display", "none");
        $("#ChequeNumberDiv").css("display", "none");
    }
    evt.stopImmediatePropagation();
});


$('#txtQuantity').on("change", function (evt) {

    var quantity = parseInt($('#txtQuantity').val());

    if (quantity == 1) {

        GetAmountForService();
    }
    else {

        var amountForService = parseInt($('#txtAmount').val());

        var value = quantity * amountForService;

        $('#txtAmount').val(value.toString());
    }


    evt.stopImmediatePropagation();
});




$('#txtHours').on("change", function (evt) {

    var additionalHours = $("#txtHours").val();
    var obj = { additionalHours: additionalHours };
    var serviceID = $('#serviceDropDownList').val();

    if (serviceID == 16) {
        AjaxCall('/Receipts/GetAdditionalAmountForChaeuffeurService', JSON.stringify(obj), 'POST').done(function (response) {

            $("#txtAmount").val(response.Cost);

        }).fail(function (error) {
            alert(error.StatusText);
        });

        function AjaxCall(url, data, type) {
            return $.ajax({
                url: url,
                type: type ? type : 'GET',
                data: data,
                contentType: 'application/json'

            });
        }
    }

    if (serviceID == 18) {
        AjaxCall('/Receipts/GetAdditionalAmountForWhiteGloveService', JSON.stringify(obj), 'POST').done(function (response) {

            $("#txtAmount").val(response.Cost);

        }).fail(function (error) {
            alert(error.StatusText);
        });

        function AjaxCall(url, data, type) {
            return $.ajax({
                url: url,
                type: type ? type : 'GET',
                data: data,
                contentType: 'application/json'

            });
        }
    }


    evt.stopImmediatePropagation();
   
 
});


$('#txtKm').on("change", function (evt) {

    var additionalKilometeres = $("#txtKm").val();
    var obj = { AdditionalKilometeres : additionalKilometeres  };

    AjaxCall('/Receipts/GetAdditionalAmountForNormalValetService', JSON.stringify(obj), 'POST').done(function (response) {

        $("#txtAmount").val(response.Cost);

    }).fail(function (error) {
        alert(error.StatusText);
    });

    function AjaxCall(url, data, type) {
        return $.ajax({
            url: url,
            type: type ? type : 'GET',
            data: data,
            contentType: 'application/json'

        });
    }

    evt.stopImmediatePropagation();
});