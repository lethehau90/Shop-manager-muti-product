$(document).ready(function () {

    $('#treeclick').tree({
        onClick: function (node) {
            // alert(node.text);
        }
    });
    $('.btn-Priority').click(function(){
     //   e.preventDefault();
        var btn = $(this);
        var Id = btn.data('id');
        $.ajax({
            url: "/Quanlywebsite/CategoryNewsAdmin/Priority",
            data: { Id: Id },
            dataType: "json",
            type: "POST",
            success: function (response) {
                if (response.Priority == 1) {
                    btn.text('Có');
                }
                else if (response.Priority == 0) {
                    btn.text('Không');
                }
                $("#update_paner").css("display", "none");
                $("#update_panerlever").css("display", "none");
                $("#update_paner_add").css("display", "none");
            }
        });
    });

    //implementted the action click in CKPriority lever 1 and lever 2
    $("#CKPriority").click(function () {

        if ($("#CKPriority").attr('checked')) {
            $("#CKPriority").removeAttr('checked');
            $("#CKPriority").val("0");
        }
        else {
            $("#CKPriority").attr('checked', 'checked');
            $("#CKPriority").val("1");
        }
    });

    //implementted the action click in CKPriority lever 3
    $("#CKTxtlevelPriority").click(function () {

        if ($("#CKTxtlevelPriority").attr('checked')) {
            $("#CKTxtlevelPriority").removeAttr('checked');
            $("#CKTxtlevelPriority").val("0");
        }
        else {
            $("#CKTxtlevelPriority").attr('checked', 'checked');
            $("#CKTxtlevelPriority").val("1");
        }
    });

});