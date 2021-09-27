//<script type="text/javascript">
////$(document).ready(function () {
////    $('#registerFormId').validate({
////        errorClass: 'help-block animation-slideDown',
////        errorElement: 'div',
////        errorPlacement: function (error, e) {
////            e.parents('.form-group > div').append(error);
////        },
////        highlight: function (e) {

////            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
////            $(e).closest('.help-block').remove();
////        },
////        success: function (e) {
////            e.closest('.form-group').removeClass('has-success has-error');
////            e.closest('.help-block').remove();
////        },
//        $(document).ready(function () {
//            $("#registerFormId").validate({
//                rules:
//                {
//                    "Name": {
//                        required: true
//                    },
//                    "Password":
//                    {
//                        required: true,
//                        minlength: 5

//                    },
//                    "ConfirmPassword":
//                    {
//                        required: true,
//                        equalTo: '#Password'
//                    },
//                    "City":
//                    {
//                        required: true
//                    },
//                    "Gender":
//                    {
//                        required: true
//                    }
//                },
//                messages:
//                {
//                    "Name": 'Please Enter Valid Name',

//                    "Password": {
//                        required: 'Please provide a password',
//                        minlength: 'Your password must be at least 5 characters long'
//                    },

//                    "ConfirmPassword": {
//                        required: 'Please provide a password',
//                        minlength: 'Your password must be at least 5 characters long',
//                        equalTo: 'Please enter the same password as above'
//                    },

//                    "City": 'Please Enter City Name',

//                    "Gender": 'Please Enter Gender'
//                },
//                submitHandler: function (registerFormId) {
//                    alert('valid form submitted');
//                    return false;
//                }
//            });
//});
//</script>