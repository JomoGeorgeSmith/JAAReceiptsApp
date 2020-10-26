//<script type="text/javascript" src="http://ajax.cdnjs.com/ajax/libs/json2/20110223/json2.js"></script>

var sum = 0;
    $("body").on("click", "#btnAdd", function (evt) {

        var txtQuantity = $("#txtQuantity");
        var txtAmount = $("#txtAmount");
        var txtAdditionalInfo = $("#AdditionalInfo");
        var service = $("#serviceDropDownList option:selected").text();

        //Get the reference of the Table's TBODY element.
        var tBody = $("#tableReceipts > TBODY")[0];

        //Add Row.
        var row = tBody.insertRow(-1);

        //Add service cell
        var cell = $(row.insertCell(-1));
        var ReceiptTypeID = $('#categoryDropDownList').val();
        if (ReceiptTypeID == 6) {

            var invoice = "Invoice: "
            cell.html(invoice.concat( txtAdditionalInfo.val() ));
        }
        else {
            cell.html(service);
        }

        //add Quantity Cell
        var ReceiptTypeID = $('#categoryDropDownList').val();
        var cell = $(row.insertCell(-1));
        if (ReceiptTypeID == 6 || ReceiptTypeID == 3) {
            cell.html(txtAdditionalInfo.val());
        }
        else {
            cell.html(txtQuantity.val());
        }

        //add Amount cell
        var serviceID = $('#serviceDropDownList').val();
        var cell = $(row.insertCell(-1));


        //cell.html(txtAmount.val());

        if (serviceID == 26) {

            cell.html("");
            var amount = parseInt(txtAmount.val());

            $("#txtTotalAmount").val(amount);
            $("#lblTotalLabel").val(amount.toString());
            $("#lblTotalLabel").text(amount.toString());

            $("#lblTotalLabel").css("visibility", "visible")
            $("#lblTotalAmountLabel").css("visibility", "visible")

        }

        else {

            cell.html(txtAmount.val());
            var amount = parseInt(txtAmount.val());

            var total = amount;
            sum += total;

            $("#txtTotalAmount").val(sum);
            $("#lblTotalLabel").val(sum.toString());
            $("#lblTotalLabel").text(sum.toString());

            $("#lblTotalLabel").css("visibility", "visible")
            $("#lblTotalAmountLabel").css("visibility", "visible")

        }

        // Add GCT Cell
        var cell = $(row.insertCell(-1));
        cell.html(txtAmount.val());

        // Add Total Cell
        var cell = $(row.insertCell(-1));
        cell.html(txtAmount.val());

        //var amount = parseInt(txtAmount.val());

        //var total = amount;
        //sum += total;
             
        //$("#txtTotalAmount").val(sum);
        //$("#lblTotalLabel").val(sum.toString());
        //$("#lblTotalLabel").text(sum.toString());
        //$("#lblTotalLabel").css("visibility", "visible")
        //$("#lblTotalAmountLabel").css("visibility", "visible")
        

        ////Add Name cell.
        //var cell = $(row.insertCell(-1));
        //cell.html(txtName.val());

        ////Add Country cell.
        //cell = $(row.insertCell(-1));
        //cell.html(txtCountry.val());

        //Add Button cell.
        //cell = $(row.insertCell(-1));
        //var btnRemove = $("<input />");
        //btnRemove.attr("type", "button");
        //btnRemove.attr("onclick", "Remove(this);");
        //btnRemove.val("Remove");
        //cell.append(btnRemove);

        //Clear the TextBoxes.
        //txtName.val("");
        //txtCountry.val("");
        
        evt.stopImmediatePropagation();
        //ClearBoxes();
    });


function GetGCT() {

}

function ClearBoxes() {
    $('#txtAmount').val("");
    $('#txtQuantity').val("");
    $('#AdditionalInfo').val("");
}



    function Remove(button) {
        //Determine the reference of the Row using the Button.
        var row = $(button).closest("TR");
        var name = $("TD", row).eq(0).html();
        if (confirm("Do you want to delete: " + name)) {
            //Get the reference of the Table.
            var table = $("#tblReceipts")[0];

            //Delete the Table row using it's Index.
            table.deleteRow(row[0].rowIndex);
        }
    };

    //$("body").on("click", "#btnSave", function () {
    //    //Loop through the Table rows and build a JSON array.
    //    var customers = new Array();
    //    $("#tblReceipts TBODY TR").each(function () {
    //        var row = $(this);
    //        var customer = { };
    //        customer.Name = row.find("TD").eq(0).html();
    //        customer.Country = row.find("TD").eq(1).html();
    //        customers.push(customer);
    //    });

    //    Send the JSON array to Controller using AJAX.
    //    $.ajax({
    //    type: "POST",
    //        url: "/Home/InsertCustomers",
    //        data: JSON.stringify(customers),
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        success: function (r) {
    //    alert(r + " record(s) inserted.");
    //        }
    //    });
    //});
    //}

//function GetTableValues() {
//    //Create an Array to hold the Table values.
//    var services = new Array();

//    //Reference the Table.
//    var table = document.getElementById("tableReceipts");

//    //Loop through Table Rows.
//    for (var i = 1; i < table.rows.length; i++) {
//        //Reference the Table Row.
//        var row = table.rows[i];

//        //Copy values from Table Cell to JSON object.
//        var service = {};
//        service.ServiceID = row.cells[0].innerHTML;
//        //customer.Name = row.cells[1].innerHTML;
//        //customer.Country = row.cells[2].innerHTML;
//        services.push(service);
//    }

//    //Convert the JSON object to string and assign to Hidden Field.
//    document.getElementsByName("ServiceJSON")[0].value = JSON.stringify(services);

//    //Send the JSON array to Controller using AJAX.
//    $.ajax(
//        {
//            type: "POST",
//            url: "/receipts/GetSelectedServices",
//            data: JSON.stringify(services),
//            contentType: "application/json; charset=utf-8",
//            dataType: "json"
//        }
//    );

//}




    





