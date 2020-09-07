
    $(function () {

        $('#categoryDropDownList').on("change", function () {
            $("#txtQuantity").val("");
            $("#txtAmount").val("");
            var ReceiptTypeID = $('#categoryDropDownList').val();
            var obj = { ReceiptTypeID: ReceiptTypeID };

            if (ReceiptTypeID == 6 ) {
                $("#QuantityDiv").css("visibility", "hidden")
                $("#QuantityDiv").css("display", "none")
                $("#AdditionalInfoDiv").css("visibility", "visible")
                $("#AdditionalInfoDiv").css("display", "")
                $("#lblAdditionalInfo").text("Invoice Number");
                $("#lblSecondColumn").text("Invoice Number");
            }

            else if (ReceiptTypeID == 3)
            {
                $("#QuantityDiv").css("visibility", "hidden")
                $("#QuantityDiv").css("display", "none")
                $("#AdditionalInfoDiv").css("visibility", "visible")
                $("#AdditionalInfoDiv").css("display", "")
                //$("#AdditionalInfoDiv").show();
                $("#lblAdditionalInfo").text("Additional Info");
                $("#lblSecondColumn").text("Additonal Info");
            }
            else {
                $("#QuantityDiv").css("visibility", "visible")
                $("#QuantityDiv").css("display", "")
                //$("#QuantityDiv").show();
                $("#AdditionalInfoDiv").css("visibility", "hidden")
                $("#AdditionalInfoDiv").css("display", "none")
                //$("#AdditionalInfoDiv").hide();
            }
      
            AjaxCall('/Receipts/GetServices', JSON.stringify(obj), 'POST').done(function (response) {
                if (response.length > 0) {
                    $('#serviceDropDownList').html('');
                    var options = '';
                    options += '<option value="Select">Select</option>';
                    for (var i = 0; i < response.length; i++) {
                        options += '<option value="' + response[i].ServiceID + '">' + JSON.stringify(response[i].Description) + '</option>';
                        
                    }
                    //$('#serviceDropDownList').append(options);
                    $('#serviceDropDownList').html(options);

                    if (ReceiptTypeID == 3) {
                        $('#serviceDropDownList').val(15);
                    }

                    if (ReceiptTypeID == 6) {
                        $('#serviceDropDownList').val(26);
                    }


                }
            }).fail(function (error) {
                alert(error.StatusText);
            });
        });
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

$('#serviceDropDownList').on("change", function () {
    var serviceID = $('#serviceDropDownList').val();
    $("#txtQuantity").val("");
    $("#txtAmount").val("");

    if (serviceID == 1 || serviceID == 4 ) {
        $("#QuantityDiv").css("visibility", "hidden");
        $("#QuantityDiv").css("display", "none");
        $("#txtQuantity").val("10");

    }

    else if (serviceID == 26 || serviceID == 15) {
        $("#QuantityDiv").css("visibility", "hidden");
        $("#QuantityDiv").css("display", "none");
 

    }

    else {
        $("#QuantityDiv").css("visibility", "visible")
        $("#QuantityDiv").css("display", "")
        $("#txtQuantity").val("");
    }
});


$('#paymentTypeDropDownList').on("change", function (evt) {
    var paymentTypeID = $('#paymentTypeDropDownList').val();
    $("#txtLastFourDigits").val("");
    $("#txtChequeNumber").val("");

    if (paymentTypeID == 2 || paymentTypeID == 3 || paymentTypeID == 4 ) {
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


