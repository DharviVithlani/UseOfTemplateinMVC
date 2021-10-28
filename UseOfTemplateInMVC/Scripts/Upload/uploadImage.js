$(function () {
    bsCustomFileInput.init();
    //bind event
    //$('#ProfileImage').on('change', function () {
    //   uploadmessage();
    //});
});
var isFileValid = false;
function OnBegin() {
    var imagename = $("#ProfileImage").val();
    if (imagename == "") {
        $('#message').text("Please choose an Image.");
        return false;
    }
    return isFileValid;
}

function OnSuccess(imagename) {
    Swal.fire(
        'Great!',
        'Your Profile has been updated successfully!',
        'success'
    )
    $("#modal-default").modal("hide");
    $('#userimage,#userprofilepicture').attr("src", "/Images/ProfileImages/" + imagename);
}

function uploadImage() {
    var ext = $("#ProfileImage").val().split('.').pop().toLowerCase();
    if ($.inArray(ext, ['gif', 'png', 'jpg', 'jpeg']) == -1) {
        isFileValid = false;
        $('#message').text("file format is incorrect.");
    }
    else {
        isFileValid = true;
        $("#message").text("");
    }
}

$("#modal-default").on('show.bs.modal', function () {
    $('#message').text("");
    $("#ProfileImage").val('');
    $('#lblImageName').text('Choose File');
});