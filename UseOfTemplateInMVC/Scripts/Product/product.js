$(document).ready(function () {
    bsCustomFileInput.init();
    DataTable = $('#tblProducts').DataTable(
        {
            "ajax":
            {
                "url": "/Product/GetAllProductDetails",
                "type": "GET",
                "datatype": "json"
            },
            "autoWidth": false,
            "columns": [
                { "data": "Title" },
                { "data": "Price" },
                {
                    mRender: function (data, type, row) {
                        var id = row['ProductId'];
                        return `<div class="row">
                                    <div class="col-md-3">
                                        <a href="/Product/Upsert/${id}" class="btn btn-block btn-outline-primary d-grid">Edit</a>
                                    </div>
                                    <div class="col-md-3">
                                        <a href="#" class="btn btn-block btn-outline-danger" onclick='ConfirmDelete(${id})'>Delete</a>
                                    </div>
                                </div>`
                    }
                },
            ]
        })
})
var ConfirmDelete = function (productid) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert " + "!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: "/Product/Delete",
                data: {
                    id: productid,
                },
                success: function () {
                    Swal.fire(
                        'Deleted!',
                        'Your record has been deleted.',
                        'success'
                    )
                    DataTable.ajax.reload();
                }
            })
        }
    })
}




