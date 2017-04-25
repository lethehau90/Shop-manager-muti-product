function get_Read_lever(Id) {
    $.ajax({
        url: '/Quanlywebsite/CategotyproductAdmin/Get_Read',
        type: "Post",
        dataType: 'json',
        data: { Id: Id },
        success: function (data) {
           
           
            $("#TxtlevelId").val(data.Id);

            //tiêu đề cập nhật theo tên
            $('.Editcatelog').text(data.Name);

            $("#TxtlevelName").val(data.Name);
            $("#TxtlevelNameEn").val(data.NameEn);

            $("#Txtlevelcontent").val(data.content);
            $("#TxtlevelcontentEn").val(data.contentEn);

            $("#TxtlevelDescription").val(data.Description);
            $("#TxtlevelKeyword").val(data.Keyword);

            $("#TxtlevelOrd").val(data.Ord);
            $("#CKTxtlevelActive").val(data.Active);
            $("#CKTxtlevelPriority").val(data.Priority);
          //  $('#Selectlevel option').removeAttr('selected').filter('[value=' + data.Level + ']').attr('selected', true);


            $("#TxtlevelLogogroup").val(data.Logogroup);

            //active
            if ($("#CKTxtlevelActive").val() == "1") {
                $("#CKTxtlevelActive").prop('cheCKTxtleveled', true); // CheCKTxtlevels it true
                $("#CKTxtlevelActive").attr('checked', 'checked');
            }
            else {
                $("#CKTxtlevelActive").prop('cheCKTxtleveled', false); // CheCKTxtlevels it false
                $("#CKTxtlevelActive").removeAttr('checked');
            }

            //active
            if ($("#CKTxtlevelPriority").val() == "1") {
                $("#CKTxtlevelPriority").prop('cheCKTxtleveled', true); // CheCKTxtlevels it true
                $("#CKTxtlevelPriority").attr('checked', 'checked');
            }
            else {
                $("#CKTxtlevelPriority").prop('cheCKTxtleveled', false); // CheCKTxtlevels it false
                $("#CKTxtlevelPriority").removeAttr('checked');
            }

            console.log(data);

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
             getcon_leve1(data.Level);
            var Idlever = $('#Selectlevel1muti_>option:selected').val();
          //  alert(Idlever);
          
            getcon_leve2(data.Level);
           
            //load img sự kiện hình ảnh

            $("#imgShowScren").attr("src", data.Logogroup); //lấy src trong data
            var img = $("#imgShowScren").attr("src"); // lấy giá trị
            if (img == "" || img == null) { //nếu null
                $("#imgShowScren").attr("src", "/Images/no-Image.jpg"); // load ảnh mặt định
            }
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
