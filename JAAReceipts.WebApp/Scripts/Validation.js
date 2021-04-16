var paymentTypeID = $('#paymentTypeDropDownList').val();

var serviceID = $('#serviceDropDownList').val();


// Wait for the DOM to be ready
$(function () {
    // Initialize form validation on the registration form.
    // It has the name attribute "registration"
    $("#create").validate({
    //    errorClass: 'help-block animation-slideDown', // You can change the animation class for a different entrance animation - check animations page  
    //    errorElement: 'div',
    //    errorPlacement: function (error, e) {
    //        e.parents('.form-group > div').append(error);
    //    },
    //    highlight: function (e) {

    //        $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
    //        $(e).closest('.help-block').remove();
    //    },
    //    success: function (e) {
    //        e.closest('.form-group').removeClass('has-success has-error');
    //        e.closest('.help-block').remove();
    //    }, 
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
        
            'Receipt.ReceivedFrom': {
                required: true, 
                minlength: 4
            },

            'Receipt.PaymentTypeID': {
                required: true
            }
            ,
            'AllReceiptTypeCategories': {
                required: true
            },
            'ServiceID': {
                required: true
            },
            txtAmount: {
                required: true
            },
            'Currencies': {
                required: true
            },   
            'Receipt.LastFourDigits':
            {
                required:
                {
                    depends: 

                    function() {
                        return
                        $('#paymentTypeDropDownList').val() == 2 ||
                            $('#paymentTypeDropDownList').val() == 3 ||
                            $('#paymentTypeDropDownList').val() == 4 ||
                            $('#paymentTypeDropDownList').val() == 5 ||
                            $('#paymentTypeDropDownList').val() == 6
                    }
                },
                maxlength : 4
            },
            'Receipt.AdditionalInfo':
            {
                required: true
                    
            },

            'txtQuantity': {
                required: true
            }

            //'txtQuantity': {
            //    required:
            //        function () {
            //            return 
            //            $('#serviceDropDownList').val() != 15 ||
            //                $('#serviceDropDownList').val() != 26 ||
            //                $('#serviceDropDownList').val() == ''
            //        }
            //}

    
            //lastname: "required",
            //email: {
            //    required: true,
            //    // Specify that email should be validated
            //    // by the built-in "email" rule
            //    email: true
            //},
            //password: {
            //    required: true,
            //    minlength: 5
            //}
        },
        // Specify validation error messages
        messages: {
            'Receipt.LastFourDigits':

            {
                required: "Please input last four digits",
                maxlength : "Must be four digits"
                
                }
            ,
            'Receipt.ReceivedFrom': {
                required: "This field cannot be empty",
                minlength: "Must Be atleast 2 characters"
            },
            'Receipt.PaymentTypeID': "You must select a payment method",
            'AllReceiptTypeCategories': "You must select a category",
            'ServiceID': "You must select a service",
            txtAmount: "This field cannot be empty",
            'Currencies': "You must select a currency", 
            'Receipt.AdditionalInfo': "This field cannot be empty",
            'txtQuantity': "This field cannot be empty"

            //password: {
            //    required: "Please provide a password",
            //    minlength: "Your password must be at least 5 characters long"
            //},
            //email: "Please enter a valid email address"
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });
});