function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/DientuLoaithuoctinhAdmin/Get_Read',
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
            $("#TxtImages").val(data.Images);
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
            $("#TxtOrd").val(data.Ord);
            ///set CKediter Content
            if (data.Content == null) //trường hợp null
            {
                CKEDITOR.instances['TxtContent'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtContent'].setData(data.Content); //set dữ liệu Ckeditor
            }
            
           // console.log(data);
           //load img sự kiện hình ảnh

            $("#imgShowScren").attr("src", data.Images); //lấy src trong data
            var img = $("#imgShowScren").attr("src"); // lấy giá trị
            if (img == "" || img == null) { //nếu null
                $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
            }
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
