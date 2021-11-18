﻿$(function () {
    //$('#txtUsername').val(getCookie("username"));
    //$('#txtPassword').val(getCookie("password"));
    //var rm = getCookie("remember");
    //$("#chkRememberMe").prop("checked", rm == "true");
    $.ajax({
        type: "GET",
        url: "/LoginV2/GetValuesFromCookies",
        success: function (data) {
            debugger
            $('#txtUsername').val(data.username);
            $('#txtPassword').val(data.password);
            var rm = data.rememberMe;
            $('#chkRememberMe').prop("checked", rm == "true");
        }
    })

    $.validator.setDefaults({
        submitHandler: function () {
            var username = $('#txtUsername').val();
            var password = $('#txtPassword').val();
            var rememberme = $('#chkRememberMe').is(':checked');

            $.ajax({
                type: "post",
                url: "/LoginV2/LoginV2",
                beforeSend: function () { loader.show() },
                data: {
                    username: username,
                    password: password,
                    rememberme: rememberme
                },
                success: function (data) {
                    loader.hide();
                    if (!data.success) {
                        if (!data.IsBlocked) {
                            toastr.error(data.errorMessage)
                        }
                        else {
                            toastr.warning(data.errorMessage)
                        }
                    }
                    else {
                        toastr.success("Logged In Successfully.")
                        ////Set and Remove Cookies from Client Side.
                        //if (rememberme == true) {
                        //    setCookie("username", $('#txtUsername').val(), 15);
                        //    setCookie("password", $('#txtPassword').val(), 15);
                        //    setCookie("remember", $('#chkRememberMe').is(':checked'), 15);
                        //}
                        //else {
                        //    removeCookie("username")
                        //    removeCookie("password")
                        //    removeCookie("remember")
                        //}
                        var id = data.id;
                        setTimeout(function () {
                            if (data.id != 0) {
                                var url = `/Registration/Registration/${id}`;
                            }
                            else {
                                var url = "/Home/Index";
                            }
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