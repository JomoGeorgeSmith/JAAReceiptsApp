// Wait for the DOM to be ready
$(function () {
    // Initialize form validation on the registration form.
    // It has the name attribute "registration"
    $("#contact").validate({
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

        'Name': {
            required: true
        },

        'Email': {
            required: true, 
                email : true
        },
        'Details': {
            required: true
        }
           
    },
    // Specify validation error messages
    messages: {
        'Name':

        {
            required: "Please input name"

        },
        'Email': {
            required: "This field cannot be empty"
        },

        'Details': "You must fill this out"

    },
    // Make sure the form is submitted to the destination defined
    // in the "action" attribute of the form when valid
    submitHandler: function (form) {
        form.submit();
    }
});
});