﻿$(document).ready(function () {
    DataTable = $('#tblMembers').DataTable(
        {
            "ajax":
            {
                "url": "/MemberV2/GetData",
                "type": "GET",
                "datatype": "json"
            },
            "columns": [
                { "data": "FullName" },
                { "data": "UserName" },
                { "data": "CountryName" },
                { "data": "StateName" },
                { "data": "CityName" },
                {
                    mRender: function (data, type, row) {
                        var id = row['UserId'];
                        var name = row['UserName'];
                        return `<div class="row">
                                    <div class="col-md-6">
                                        <a href="/Registration/Registration/${id}" class="btn btn-block btn-outline-primary d-grid">Edit</a>
                                    </div>
                                    <div class="col-md-6">
                                        <a href="#" class="btn btn-block btn-outline-danger" onclick='ConfirmDelete(${id},"${name}")'>Delete</a>
                                    </div>
                                </div>`
                    }
                },
            ],
            fnRowCallback: function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
                if (aData.IsActive == true) {
                    $('td', nRow).css('background-color', '#F3FFF9');
                } else {
                    $('td', nRow).css('background-color', '#FFF3F3');
                }       
            }
        });
});
var ConfirmDelete = function (userid, username) {
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
            $.ajax({
                type: "POST",
                url: "/MemberV2/Delete",
                data: {
                    id: userid,
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