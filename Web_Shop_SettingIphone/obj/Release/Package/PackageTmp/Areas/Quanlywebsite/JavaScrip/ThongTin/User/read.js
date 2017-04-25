function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/UserAdmin/Get_Read',
        type: "Post",
        dataType: 'json',
        data: { Id: Id },
        success: function (data) {

            $("#TxtId").val(data.Id);
            $("#TxtName").val(data.Name);
            $("#TxtUsername").val(data.Username);
            $("#TxtOrd").val(data.Ord);
            $("#CKActive").val(data.Active);
            //check active
            if ($("#CKActive").val() == "1") {
                $("#CKActive").prop('checked', true); // Checks it true
                $("#CKActive").attr('checked', 'checked');
            }
            else {
                $("#CKActive").prop('checked', false); // Checks it false
                $("#CKActive").removeAttr('checked');
            }
            $('#SelectRole option').removeAttr('selected').filter('[value=' + data.Role + ']').attr('selected', true);
           
            //console.log($("#TxtOrd").val());
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
