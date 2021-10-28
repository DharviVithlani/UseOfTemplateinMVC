$(document).ready(function () {
    setTimeout(function () {
        $("#msg").fadeOut();
    }, 5000);

    $("#CountryId").change(function () {
        var countryid = $(this).val();
        $.ajax({
            type: "GET",
            url: "/Registration/GetStateList?CountryId=" + countryid,
            contentType: "html",
            success: function (response) {
                $("#StateId").empty();
                $("#CityId").empty();
                $("#StateId").append(response);
                $("#CityId").append('<option value="0">Select City</option>');
            }
        });
    });

    $("#StateId").change(function () {
        var stateid = $(this).val();
        $.ajax({
            type: "GET",
            url: "/Registration/GetCityList?StateId=" + stateid,
            contentType: "html",
            success: function (response) {
                $("#CityId").empty();
                $("#CityId").append(response);
            }
        });
    });
});