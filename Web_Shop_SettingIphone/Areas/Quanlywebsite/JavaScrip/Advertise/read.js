function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/ImagesAdvertiseAdmin/Get_Read',
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
            $("#TxtImage").val(data.Image);

            $("#TxtLink").val(data.Link);
            //Select Target   
            $('#SelectTarget option').removeAttr('selected').filter('[value=' + data.Target + ']').attr('selected', true);
            ///set CKediter Content
            if (data.Content == null) //trường hợp null
            {
                CKEDITOR.instances['TxtContent'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtContent'].setData(data.Content); //set dữ liệu Ckeditor
            }
            //SelectPosition vị trí quảng cáo trong trang
            $('#SelectPosition option').removeAttr('selected').filter('[value=' + data.Position + ']').attr('selected', true);

            //SelectPageId vị trí Loại Quảng cáo
            $('#SelectPageId option').removeAttr('selected').filter('[value=' + data.PageId + ']').attr('selected', true);

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

            if (data.ContentEn == null) //set về rỗng
            {
                CKEDITOR.instances['TxtContentEn'].setData("");
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtContentEn'].setData(data.ContentEn); //set dữ liệu Ckeditor
            }
            
            //thiet lap ngay tao
            if (data.Ngaytao == null || data.Ngaytao =="")
            {
                $("#datepickerNgaytao").val("");
            }
            else
            {
                $("#datepickerNgaytao").val(parseJsonDate(data.Ngaytao));
            }
            //thiet lap ngay het han
            if (data.Ngayhethan == null || data.Ngayhethan == "") {
                $("#datepickerNgayhethan").val("");
            }
            else {
                $("#datepickerNgayhethan").val(parseJsonDate(data.Ngayhethan));
            }
            
           // console.log(data);
            //load img sự kiện hình ảnh

            $("#imgShowScren").attr("src", data.Image); //lấy src trong data
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
