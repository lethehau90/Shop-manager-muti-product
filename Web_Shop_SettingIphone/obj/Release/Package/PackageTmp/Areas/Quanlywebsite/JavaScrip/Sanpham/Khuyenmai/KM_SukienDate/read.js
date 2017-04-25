function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/KM_SukienDateAdmin/Get_Read',
        type: "Post",
        dataType: 'json',
        data: { Id: Id },
        success: function (data) {
           
            /* Before serialize */
            for (instance in CKEDITOR.instances) {
                CKEDITOR.instances[instance].updateElement();
            }
            $("#TxtId").val(data.Id);

            //tiêu đề cập nhật theo tên
            $('.Editcatelog').text(data.Name);

            $("#TxtName").val(data.Name);
            $("#TxtPrice_event").val(data.Price_event);

           
            ///set CKediter content
            if (data.content == null) //trường hợp null
            {
                CKEDITOR.instances['Txtcontent'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['Txtcontent'].setData(data.content); //set dữ liệu Ckeditor
            }
          

            $("#TxtOrd").val(data.Ord);

            //active
            $("#CKActive").val(data.Active);
            if ($("#CKActive").val() == "true") {
                $("#CKActive").prop('checked', true); // Checks it true
                $("#CKActive").attr('checked', 'checked');
                $("#CKActive").val("1");
            }
            else {
                $("#CKActive").prop('checked', false); // Checks it false
                $("#CKActive").removeAttr('checked');
                $("#CKActive").val("0");
            }


            $("#TxtNameEn").val(data.NameEn);

            if (data.contentEn == null) //set về rỗng
            {
                CKEDITOR.instances['TxtcontentEn'].setData("");
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtcontentEn'].setData(data.contentEn); //set dữ liệu Ckeditor
            }
            
            //thiet lap ngay tao
            if (data.Date_event_start == null || data.Date_event_start =="")
            {
                $("#Date_event_start").val("");
            }
            else
            {
                $("#Date_event_start").val(parseJsonDate(data.Date_event_start));
            }
            //thiet lap ngay het han
            if (data.Date_event_end == null || data.Date_event_end == "") {
                $("#Date_event_end").val("");
            }
            else {
                $("#Date_event_end").val(parseJsonDate(data.Date_event_end));
            }
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
