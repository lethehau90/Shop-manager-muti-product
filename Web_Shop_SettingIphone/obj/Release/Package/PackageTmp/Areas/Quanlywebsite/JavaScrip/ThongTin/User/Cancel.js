$(document).ready(function () {
    $('#Cancel').click(function () {
        var object = {
            Name: $("#TxtName").val(),
            Username: $("#TxtUsername").val(),
            Password: $("#TxtPassword").val(),
            ConfirmPassword: $("#TxtConfirmPassword").val(),
            Ord: $("#TxtOrd").val(),
            Active: ""
        };
        // đưa giá trị actice chek
        var check = $("#CKActive:checked").val();
        if (check == "1") {
            object.Active = "1"; //gán giá trị 1 (true) có kích hoạt
        }
        else {
            object.Active = "0"; //gán giá trị 0 (false) không kích hoạt
        }
        $.each(object, function (key, item) {
            $("#Txt" + key).val("");
            $("#TxtOrd").val("1");
            $("#CKActive").val("1");
        });
        $('#SelectRole option').removeAttr('selected').filter('[value=Personnel]').attr('selected', true);
        return false;
    });
});