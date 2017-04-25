$(document).ready(function () {
    //chạy click treeclick
    $('#treeclick').tree({
        onClick: function (node) {
            // alert(node.text);
        }
    });
    $('.btn-active').off('click').on('click', function (e) {
        e.preventDefault();
        var btn = $(this);
        var Id = btn.data('id');
        $.ajax({
            url: "/Quanlywebsite/CategoryNewsAdmin/Active",
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
                //load jaavscrip đầu vào ẩn hết
                $("#update_paner").css("display", "none");
                $("#update_panerlever").css("display", "none");
                $("#update_paner_add").css("display", "none");
            }
        });
    });

    //implementted the action click in active lever 1 and lever 2
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

    //implementted the action click in active lever 3
    $("#CKTxtlevelActive").click(function () {

        if ($("#CKTxtlevelActive").attr('checked')) {
            $("#CKTxtlevelActive").removeAttr('checked');
            $("#CKTxtlevelActive").val("0");
        }
        else {
            $("#CKTxtlevelActive").attr('checked', 'checked');
            $("#CKTxtlevelActive").val("1");
        }
    });

});

//Quyền trang chủ hay không

