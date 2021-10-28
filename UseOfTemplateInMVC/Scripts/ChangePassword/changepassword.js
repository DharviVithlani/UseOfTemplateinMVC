function onSuccess(data) {
    if (data.success == true) {
        Swal.fire(
            'Congratulations!!',
            'Your password has been successfully changed. To confirm your new password, you will be required to log back into the website.',
            'success'
        ).then(function () {
            var url = "/LoginV2/Logout";
            window.location.href = url;
        });
        // $("#modal-UpdatedPassword").modal('show');
    }
    else {
        if (data.displayMethod == "error") {
            toastr.error("Current password is incorrect.")
        }
        else {
            Swal.fire(
                '',
                'You can not use your current password as your new password. Please use another.',
                'warning'
            )
        }
    }
}