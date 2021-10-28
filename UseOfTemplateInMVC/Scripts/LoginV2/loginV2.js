$(function () {
    $.validator.setDefaults({
        submitHandler: function () {
            var username = $('#exampleInputEmail1').val();
            var password = $('#exampleInputPassword1').val();
            $.ajax({
                type: "post",
                url: "/LoginV2/LoginV2",
                data: {
                    username: username,
                    password: password
                },
                success: function (data) {
                    if (!data.success) {
                        toastr.error(data.errorMessage)
                    }
                    else {
                        toastr.success("Logged In Successfully.")
                        setTimeout(function () {
                            var url = "/Home/Index";
                            window.location.replace(url);
                        }, 1000)
                    }
                }
            })
        }
    })
    $('#quickForm').validate({
        rules: {
            username: {
                required: true,
            },
            password: {
                required: true,
            },
        },
        messages: {
            username: {
                required: "Username is required.",
            },
            password: {
                required: "Password is required.",
            },
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.form-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        }
    });
});