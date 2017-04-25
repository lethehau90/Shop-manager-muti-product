$(document).ready(function () {
    $('.btn-active').off('click').on('click', function (e) {
        e.preventDefault();
        var btn = $(this);
        var Id = btn.data('id');
        $.ajax({
            url: "/Quanlywebsite/DientuMathangAdmin/Active",
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

function activett(IdTag) {
    $.ajax({
        url: "/Quanlywebsite/DientuThuoctinhAdmin/Active",
        data: { IdTag: IdTag },
        dataType: "json",
        type: "POST",
        success: function (response) {
            getloadthuoctinh($("#TxtId").val()); //load lại thuộc tính
           // $("#update_paner").css("display", "none");//ẩn panner
        }
    });
}

function activech(IdTag) {
    $.ajax({
        url: "/Quanlywebsite/DientuChitiethinhAdmin/Active",
        data: { IdTag: IdTag },
        dataType: "json",
        type: "POST",
        success: function (response) {
            getloadcauhinh($("#TxtId").val()); //load lại thuộc tính
            // $("#update_paner").css("display", "none");//ẩn panner
        }
    });
}

//implementted the action click in active
$("#CKActiveCH").click(function () {

    if ($("#CKActiveCH").attr('checked')) {
        $("#CKActiveCH").removeAttr('checked');
        $("#CKActiveCH").val("0");
    }
    else {
        $("#CKActiveCH").attr('checked', 'checked');
        $("#CKActiveCH").val("1");
    }
});
//implementted the action click in active
$("#CKActiveTT").click(function () {

    if ($("#CKActiveTT").attr('checked')) {
        $("#CKActiveTT").removeAttr('checked');
        $("#CKActiveTT").val("0");
    }
    else {
        $("#CKActiveTT").attr('checked', 'checked');
        $("#CKActiveTT").val("1");
    }
});