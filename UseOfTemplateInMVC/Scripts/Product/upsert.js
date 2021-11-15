$('#btnAddProduct').click(function () {
    var productImg = $('#ProductImage').val();
    if (productImg == "") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please choose an image.',
        })
        return false;
    }
    return true;
})