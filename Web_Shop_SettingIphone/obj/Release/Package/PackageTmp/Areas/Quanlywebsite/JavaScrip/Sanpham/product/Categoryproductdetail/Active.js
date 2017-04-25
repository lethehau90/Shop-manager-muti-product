$(document).ready(function () {
    $('.btn-active').off('click').on('click', function (e) {
        e.preventDefault();
        var btn = $(this);
        var Id = btn.data('id');
        $.ajax({
            url: "/Quanlywebsite/CategotyproductdetailAdmin/Active",
            data: { Id: Id },
            dataType: "json",
            type: "POST",
            success: function (response) {
                   if (response.Active == 1) {
                        btn.text('Có');
                    }
                    else if (response.Active == 0) {
                        btn.text('Không');
                    }
                $("#update_paner").css("display", "none");//ẩn panner
            }
        });
    });

    //implementted the action click in active
    $("#CKActive").click(function () {

        if ($("#CKActive").attr('checked')) {
            $("#CKActive").removeAttr('checked');
            $("#CKActive").val("0");
        }
        else {
            $("#CKActive").attr('checked', 'checked');
            $("#CKActive").val("1");
        }
    });

    $("#CKVat").click(function () {

        if ($("#CKVat").attr('checked')) {
            $("#CKVat").removeAttr('checked');
            $("#CKVat").val("0");
        }
        else {
            $("#CKVat").attr('checked', 'checked');
            $("#CKVat").val("1");
        }
    });

    
});