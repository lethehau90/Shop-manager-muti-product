function get_Read_lever(Id) {
    $.ajax({
        url: '/Quanlywebsite/DientuTinhnangAdmin/Get_Read',
        type: "Post",
        dataType: 'json',
        data: { Id: Id },
        success: function (data) {
           
           
            $("#TxtlevelId").val(data.Idthuoctinh);

            //tiêu đề cập nhật theo tên
            $('.Editcatelog').text(data.Thuoctinh);

            $("#TxtlevelName").val(data.Thuoctinh);

            $("#Txtlevelcontent").val(data.Content);

            $("#TxtlevelOrd").val(data.Ord);
            $("#CKTxtlevelActive").val(data.Active);
            //  $('#Selectlevel option').removeAttr('selected').filter('[value=' + data.Idtinhang + ']').attr('selected', true);


            //active
            if ($("#CKTxtlevelActive").val() == "true") {
                $("#CKTxtlevelActive").prop('cheCKTxtleveled', true); // CheCKTxtlevels it true
                $("#CKTxtlevelActive").attr('checked', 'checked');
            }
            else {
                $("#CKTxtlevelActive").prop('cheCKTxtleveled', false); // CheCKTxtlevels it false
                $("#CKTxtlevelActive").removeAttr('checked');
            }

           // console.log(data);

            //// var Idlever = $('#Selectlevel>option:selected').val();
            //if (data.Level == null || data.Level == "")
            //{
            //    $("#Selectlevelmuti_").addClass("hidden");
            //    $("#Selectlevel_").prop("disabled", true);
            //}
            //else
            //{
            //    ddlchaChange(data.Level);
            //    $("#Selectlevel_").prop("disabled", true);
            //}
         
            // disble select danh mục
            $("#Selectlevel1muti_").attr('disabled', 'disabled');
            $("#Selectlevel2muti_").attr('disabled', 'disabled');
            getcon_leve1(data.Idtinhang);
            var Idlever = $('#Selectlevel1muti_>option:selected').val();
          //  alert(Idlever);
          
            getcon_leve2(data.Idtinhang);
           
            //load img sự kiện hình ảnh

            //$("#imgShowScren").attr("src", data.Logogroup); //lấy src trong data
            //var img = $("#imgShowScren").attr("src"); // lấy giá trị
            //if (img == "" || img == null) { //nếu null
            //    $("#imgShowScren").attr("src", "/Images/no-Image.jpg"); // load ảnh mặt định
            //}
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
