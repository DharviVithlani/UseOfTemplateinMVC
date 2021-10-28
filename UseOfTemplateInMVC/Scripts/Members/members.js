function showLoader(buttonType) {
    loader.show();
    if (buttonType == 'close') {
        $("#txtsearch").val('');
    }
    setTimeout(function () {
        $("#formsubmit").submit();
    }, 300)
}

var ConfirmDelete = function (userid, username) {
    //$("#hiddenuserid").val(userid);
    //$("#lblusername").text(username);
    // $("#modal-delete").modal('show');
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert " + username + "!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            // var id = $("#hiddenuserid").val();
            var search = $("#txtsearch").val();
            $.ajax({
                type: "POST",
                url: "/Members/Delete",
                data: {
                    id: userid,
                    search: search
                },
                success: function (result) {
                    Swal.fire(
                        'Deleted!',
                        'Your record has been deleted.',
                        'success'
                    )
                    $("#row_" + userid).remove();
                    if (result == 0) {
                        markup = "<tr><td colspan='5' class='text-center'>Records not found.</td></tr>";
                        tableBody = $("table tbody");
                        tableBody.append(markup);
                    }
                }
            })
        }
    })
}
    //var DeleteUser = function () {
    //    var id = $("#hiddenuserid").val();
    //    var search = $("#txtsearch").val();
    //    $.ajax({
    //        type: "POST",
    //        url: "/Members/Delete",
    //        data: {
    //            id: id,
    //            search: search
    //        },
    //        success: function (result) {
    //            $("#modal-delete").modal("hide");
    //            $("#row_" + id).remove();
    //            if (result == 0) {
    //                markup = "<tr><td colspan='5' class='text-center'>Records not found</td></tr>";
    //                tableBody = $("table tbody");
    //                tableBody.append(markup);
    //            }
    //        }
    //    })
    //}