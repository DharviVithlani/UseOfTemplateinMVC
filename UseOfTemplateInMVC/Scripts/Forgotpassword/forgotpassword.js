$(function () {
        $.validator.setDefaults({
            submitHandler: function () {
                var userName = $("#txtusername").val();
                $.ajax({
                    type: "POST",
                    url: "/ForgotPassword/ForgotPassword",
                    beforeSend: function () { loader.show() },
                    data: {
                        username: userName
                    },
                    success: function (showPopup) {
                        loader.hide();
                        if (!showPopup) {
                            toastr.error("Your Username is not exists in our system. Please create an account.")
                        }
                        else {
                            Swal.fire(
                                'Email sent!',
                                'Please check your Email [' + userName + ']!',
                                'success'
                            ).then(function () {
                                window.location = "/LoginV2/LoginV2";
                            });
                            // $("#lblusername").text(userName);
                            // $("#modal-ForgotPassword").modal('show');
                        }
                    }
                })
            }
        })
        $('#quickForm').validate({
            rules: {
                username: {
                    required: true,
                }
            },
            messages: {
                username: {
                    required: "Username is required.",
                }
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