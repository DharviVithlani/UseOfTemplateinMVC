function showHidePassword(element) {
    $(element).toggleClass("fa-eye fa-eye-slash");
    var passInput = $(element).parent().parent().prev();
    if (passInput.attr('type') == 'password') {
        passInput.attr('type', 'text');
    } else {
        passInput.attr('type', 'password');
    }
}
