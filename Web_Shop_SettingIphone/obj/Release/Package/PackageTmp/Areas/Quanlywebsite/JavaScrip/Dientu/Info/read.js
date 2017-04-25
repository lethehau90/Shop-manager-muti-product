function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/DientuInfoAdmin/Get_Read',
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
            $('.Editcatelog').text(data.Hovaten);

            $("#TxtHovaten").val(data.Hovaten);

            $("#TxtThuonghieu").val(data.Thuonghieu);
            $("#TxtDongmay").val(data.Dongmay);
            $("#TxtSoseri").val(data.Soseri);
            $("#TxtSodienthoai").val(data.Sodienthoai);

            $(".TxtImages1").text(data.Images1);
            $(".TxtImages2").text(data.Images2);

            $("#TxtImages1").attr("href", data.Images1);
            $("#TxtImages2").attr("href", data.Images2);

            $("#TxtGiaban").val(data.Giaban);

            $("#CKActive").val(data.Active);
           ///set CKediter
            if (data.Noidungsuachua == null) //trường hợp null
            {
                CKEDITOR.instances['TxtNoidungsuachua'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtNoidungsuachua'].setData(data.Noidungsuachua); //set dữ liệu Ckeditor
            }
           
            //check active
            if ($("#CKActive").val() == "1") {
                $("#CKActive").prop('checked', true); // Checks it true
                $("#CKActive").attr('checked', 'checked');
            }
            else {
                $("#CKActive").prop('checked', false); // Checks it false
                $("#CKActive").removeAttr('checked');
            }

         
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
