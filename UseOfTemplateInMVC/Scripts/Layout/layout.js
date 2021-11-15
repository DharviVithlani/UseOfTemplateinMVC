window.onload = function () {
    var current = location.pathname;
    $('#nav li a').each(function () {
        var $this = $(this);
        if ($this.attr('href').indexOf(current) !== -1) {
            $this.addClass('active');
        }
    })

    if (localStorage.theme == "") {
        $('body').removeClass('dark-mode')
    }
    else {
        $('body').addClass('dark-mode');
        $('#DarkMode').attr('checked', 'checked');
        // $('#DarkMode').trigger('click');
    }
};

function DarkModeOnOff() {
    if ($('#DarkMode').is(':checked')) {
        $('body').addClass('dark-mode')
        localStorage.setItem("theme", "dark-mode")
    } else {
        $('body').removeClass('dark-mode')
        localStorage.setItem("theme", "")
    }
}