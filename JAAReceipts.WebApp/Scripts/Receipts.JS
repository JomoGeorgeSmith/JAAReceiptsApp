
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

            if (ReceiptTypeID == 6 ) {
                $("#QuantityDiv").css("visibility", "hidden")
                $("#QuantityDiv").css("display", "none")

                $("#AdditionalInfoDiv").css("visibility", "visible")
                $("#AdditionalInfoDiv").css("display", "")

                $("#lblAdditionalInfo").text("Invoice Number");
                $("#lblSecondColumn").text("Invoice Number");

                $("#CustomerIDDiv").css("visibility", "visible")
                $("#CustomerIDDiv").css("display", "")

                $("#ServiceDiv").css("visibility", "hidden")
                //$("#ServiceDiv").css("display", "none")

                //$("#cooperateClientDiv").css("visibility", "visible")
                //$("#cooperateClientDiv").css("display", "")
            }

            //Wrecker
            else if (ReceiptTypeID == 37) {

                $("#ServiceDiv").css("visibility", "visible")
                $("#ServiceDiv").css("display", "")

                $("#QuantityDiv").css("visibility", "hidden")
                $("#QuantityDiv").css("display", "none")


                $("#AdditionalInfoDiv").css("visibility", "hidden")
                $("#AdditionalInfoDiv").css("display", "none")

               // $('#serviceDropDownList').val(158);

                GetAmountForWreckerService()
            }

                //Asset Disposal 
            else if (ReceiptTypeID == 3)
            {

                $("#ServiceDiv").css("visibility", "visible")
                $("#ServiceDiv").css("display", "") 

                $("#QuantityDiv").css("visibility", "hidden")
                $("#QuantityDiv").css("display", "none")

                $("#AdditionalInfoDiv").css("visibility", "visible")
                $("#AdditionalInfoDiv").css("display", "")

                $("#lblAdditionalInfo").text("Additional Info");
                $("#lblSecondColumn").text("Additonal Info");

                $("#CustomerIDDiv").css("visibility", "hidden")
                $("#CustomerIDDiv").css("display", "none")
            }

            else {

                $("#ServiceDiv").css("visibility", "visible")
                $("#ServiceDiv").css("display", "") 

                $("#QuantityDiv").css("visibility", "visible")
                $("#QuantityDiv").css("display", "")

                $("#AdditionalInfoDiv").css("visibility", "hidden")
                $("#AdditionalInfoDiv").css("display", "none")

                $("#CustomerIDDiv").css("visibility", "hidden")
                $("#CustomerIDDiv").css("display", "none")

                $("#cooperateClientDiv").css("visibility", "hidden")
                $("#cooperateClientDiv").css("display", "none")
            }


            var currenciesDropDownList = $("#currenciesDropDownList").val();

      
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

//var invoiceAmounts;

function SupplyInvoiceAmount() {
    var amount = $('#txtInvoiceAmount').val();
    //invoiceAmounts = amount;
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

//var Currency = new Array();

//function SupplyCurrency() {
//    var currencyId = $('#txtQuantity').val();
//    Currency.push(currencyId);

//}


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

function PushCurrencyId() {

    var currency = $("#currenciesDropDownList").val();
    var obj = { currencyID: currency };
    //$.ajax(
    //    {
    //        type: "POST",
    //        url: "/receipts/PushCurrencyId",
    //        data: JSON.stringify(currency),
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json"
    //    }
    //);


    AjaxCall('/receipts/PushCurrencyId', JSON.stringify(obj), 'POST').done(function (response) {

        // $("#txtAmount").val(response.Cost);

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

function CustomAdd() {

    //var serviceID = $('#serviceDropDownList').val();

    //if (serviceID == 6) {
    //    SupplyInvoiceAmount();
    //}
    //else {
    //    SupplyServiceAmount();
    //}
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

    PushCurrencyId();
}

function GenerateBatch() {

    var startDate = $('#txtstartDate').val();

    var endDate = $('#txtendDate').val();

    var obj = { StartDate: startDate , EndDate: endDate };

    AjaxCall('/Receipts/GenerateCSVBatchPost', JSON.stringify(obj), 'POST').done(function (response) {

        //alert("File generated, click download to save document.");


    }).fail(function (error) {
        alert(error.StatusText);
    });

    function AjaxCall(url, data, type) {
        return $.ajax({
            url: url,
            type: type ? type : 'GET',
            data: data,
            contentType: 'application/json',
            success: function (returnValue) {
            window.location = "/Receipts/DownloadFile2";
            }

        });
    }


}

function DownloadFile() {

    //var startDate = $('#txtstartDate').val();

    //var endDate = $('#txtendDate').val();

    //var obj = { StartDate: startDate, EndDate: endDate };

      var obj = {  };

    AjaxCall('/Receipts/DownloadFile', JSON.stringify(obj), 'POST').done(function (response) {

        //alert("File generated and saved to documents");



        


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



//var serviceID = $('#serviceDropDownList').val()


function GetAmountForWreckerService() {

    //var serviceID = $('#serviceDropDownList').val();
    var serviceID = 158
    $("#txtQuantity").val("");
    $("#txtAmount").val("");

    var obj = { ServiceID: serviceID };

    AjaxCall('/Receipts/GetAmountForService', JSON.stringify(obj), 'POST').done(function (response) {
        if (response.length > 0) {
            for (var i = 0; i < response.length; i++) {

                var cost = response[i].Cost
                $("#txtAmount").val(cost);
                $("#txtQuantity").val("1");

                var currencyId = response[i].CurrencyID

                $("#currenciesDropDownList").val(currencyId);

                var amount = cost;
                var obj2 = { amount: amount };

                if (response[i].GCT == true) {

                    AjaxCall('/Receipts/CalculateGCTHttp', JSON.stringify(obj2), 'POST').done(function (response) {

                        var gct = response;
                        //$("#txtGCTAmount").val(gct);
                        $("#txtGCTAmount").val(parseFloat(gct).toFixed(2));

                        //var totalWithGCT = parseFloat(gct) + parseFloat(cost);
                        var totalWithGCT = parseFloat( parseFloat(gct).toFixed(2) ) + parseFloat(cost);
                        $("#txtAmountWithGCT").val(totalWithGCT);

                    }).fail(function (error) {
                        alert(error.StatusText);
                    });

                }

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

function NewDownload() {

    //$.ajax({
    //    type: "POST",
    //    url: '@Url.Action("ExportCSV","Receipts")', //call your controller and action
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //}).done(function (data) {
    //    //console.log(data.result);

    //    //get the file name for download
    //    if (data.fileName != "") {
    //        //use window.location.href for redirect to download action for download the file
    //        var ref = '@Url.RouteUrl(new { Controller = "Receipts", Action = "Download" }) /? file ='+ data.fileName;
    //        window.location.href = ref;
    //    }
    //});


    var obj = {  };

    AjaxCall('/Receipts/ExportCSV', JSON.stringify(obj), 'POST').done(function (response) {
        if (response.length > 0) {
            for (var i = 0; i < response.length; i++) {


            }
        }

    }).done(function (data) {

        //get the file name for download
        if (data.fileName != "") {


            //var file = data.fileName;

            //var obj2 = { file: file };

            //window.location.href = "/Receipts/DownloadFile";

            //$('#downloadButton').html('');


        }

    });

    function AjaxCall(url, data, type) {
        return $.ajax({
            url: url,
            type: type ? type : 'GET',
            data: data,
            contentType: 'application/json',
            success: function (returnValue) {
                window.location = "/Receipts/DownloadFile2";
            }

        });
    }


}

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




$('#txtAmount').on("change", function (evt) {

    var serviceID = $('#serviceDropDownList').val();

    //Asset Disposal
    if (serviceID == 15) {

        $("#txtGCTAmount").val(0);

        $("#txtAmountWithGCT").val(parseFloat($("#txtAmount").val()));

        //$("#txtQuantity").val("1");

    }

    evt.stopImmediatePropagation();
});

$('#serviceDropDownList').on("change", function (evt) {
    var serviceID = $('#serviceDropDownList').val();
    $("#txtQuantity").val("");
    $("#txtAmount").val("");
    $("#txtHours").val("");
    $("#txtKm").val("");

    var ReceiptTypeID = $('#categoryDropDownList').val();

    GetCurrency();

    var obj = { ServiceID: serviceID };
    //var obj2 = { Amount: amount }

    //As long as we arent dealing with Invoices or Asset Disposal 
    if (serviceID != 26 || serviceID != 15) {

        AjaxCall('/Receipts/GetAmountForService', JSON.stringify(obj), 'POST').done(function (response) {
            if (response.length > 0) {
                for (var i = 0; i < response.length; i++) {
                    var cost = response[i].Cost

                    var amount = cost;
                    var obj2 = { amount: amount };

                    $("#txtAmount").val(cost);
                    $("#txtQuantity").val("1");

                    if (response[i].GCT == true) {

                        AjaxCall('/Receipts/CalculateGCTHttp', JSON.stringify(obj2), 'POST').done(function (response) {

                            var gct = response;
                            $("#txtGCTAmount").val(gct);

                            var totalWithGCT = parseFloat(gct) + parseFloat(cost);
                            $("#txtAmountWithGCT").val(totalWithGCT);

                        }).fail(function (error) {
                            alert(error.StatusText);
                        });

                    }
                    //if (response[i].ServiceID == 15) {
                    //    $("#txtGCTAmount").val(0);

                    //    //$("#txtAmountWithGCT").val(parseFloat($("#txtAmount").val()));
                    //}

                    else {
                        $("#txtGCTAmount").val(0);

                        $("#txtAmountWithGCT").val(parseFloat(cost));
                    }

            
                }
            }


        //AjaxCall('/Receipts/GetAmountForService2', JSON.stringify(obj), 'POST').done(function (response) {
        //            var cost = response.Cost
        //            $("#txtAmount").val(cost);
        //            $("#txtQuantity").val("1");


           


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
    //$("#txtLastFourDigits").val("");
    $("#txtChequeNumber").val("");
    //$("#txtCreditCardType").val("");

    if (paymentTypeID == 2 || paymentTypeID == 3 || paymentTypeID == 4 ||  paymentTypeID == 5 
        || paymentTypeID == 6 || paymentTypeID == 13) {
        $("#LastFourDigitsDiv").css("visibility", "visible");
        $("#LastFourDigitsDiv").css("display", "");
        $("#ChequeNumberDiv").css("visibility", "hidden");
        $("#ChequeNumberDiv").css("display", "none");

    }

    //else if (paymentTypeID == 4 ) {
    //    $("#LastFourDigitsDiv").css("visibility", "visible");
    //    $("#LastFourDigitsDiv").css("display", "");
    //    $("#ChequeNumberDiv").css("visibility", "hidden");
    //    $("#ChequeNumberDiv").css("display", "none");

    //}

    else if ( paymentTypeID == 8 )
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

//$('#txtCustomerID').on("change", function (evt) {

//    var customerID = $('#txtCustomerID').val();

//    $('#txtReceivedFrom').val(customerID.toString());


//    evt.stopImmediatePropagation();
//});




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


$('#txtSendEmail').on("click", function (evt) {

    var emailAdress = $("#txtEmailAdress").val();
    var obj = { emailAdress: emailAdress  };

    Email();
    evt.stopImmediatePropagation();


});



//$('#btnEmail').click( function (evt) {
//    var obj = {  };


//    AjaxCall('/Receipts/Receipts', JSON.stringify(obj), 'POST').done(function (response) {



//    }).fail(function (error) {
//        alert(error.StatusText);
//    });

//    function AjaxCall(url, data, type) {
//        return $.ajax({
//            url: url,
//            type: type ? type : 'GET',
//            data: data,
//            contentType: 'application/json'

//        });
//    }

//    evt.stopImmediatePropagation();
//});

function GetCurrency()
{

    var serviceID = $('#serviceDropDownList').val();


    var obj = { ServiceID: serviceID };

    AjaxCall('/Receipts/GetAmountForService', JSON.stringify(obj), 'POST').done(function (response) {
        if (response.length > 0) {
            for (var i = 0; i < response.length; i++) {
                var currencyId = response[i].CurrencyID
                //var currenciesDropDownList = $("#currenciesDropDownList").val();
                $("#currenciesDropDownList").val(currencyId);
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

 

        // AjaxCall('/Receipts/GetAdditionalAmountForChaeuffeurService', JSON.stringify(obj), 'POST').done(function (response) {

        //    $("#txtAmount").val(response.Cost);

        //}).fail(function (error) {
        //    alert(error.StatusText);
        //});

        function AjaxCall(url, data, type) {
            return $.ajax({
                url: url,
                type: type ? type : 'GET',
                data: data,
                contentType: 'application/json'

            });
        }


    }

        

function Email() {

    var receiptId = $("#txtReceiptID").val();
    var receiptTypeId = $("#txtReceiptTypeId").val();
    var email = $("#txtEmailAddress").val();
    
    var obj = { receiptId: receiptId, receiptTypeId: receiptTypeId ,email:email};

    //AjaxCall('/Receipts/Email', JSON.stringify(obj), 'POST').done(function (response) {

    //}).fail(function (error) {
    //    alert(error.StatusText);
    //});

    $.ajax(
        {
            type: "POST",
            url: "/Receipts/Email",
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            //success: function (returnValue) {
            //    alert("Receipt Sent to " + email.toString());
            //}
        }

    );

    alert("Receipt Sent to " + email.toString());
}


$("#DateId").daterangepicker(
    {
        "singleDatePicker": true,
        "startDate": moment(),
        "endDate": moment().endOf('year'),
        "opens": "center"
    });