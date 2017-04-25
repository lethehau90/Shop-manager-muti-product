function get_Copy(Id) {
    $.ajax({
        url: '/Quanlywebsite/CategoryNewsDetailsAdmin/Get_Read',
        type: "Post",
        dataType: 'json',
        data: { Id: Id },
        success: function (data) {
           
            /* Before serialize */
            for (instance in CKEDITOR.instances) {
                CKEDITOR.instances[instance].updateElement();
            }
            $("#TxtId").val("");

            //tiêu đề cập nhật theo tên
            $('.Editcatelog').text("mới");

            $("#TxtName").val(data.Name);
            $("#TxtNameEn").val(data.NameEn);
           
            $("#TxtContent").val(data.Content);

            ///set CKediter Content
            if (data.Detail == null) //trường hợp null
            {
                CKEDITOR.instances['TxtDetail'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtDetail'].setData(data.Detail); //set dữ liệu Ckeditor
            }
            $("#TxtContentEn").val(data.ContentEn);

            if (data.DetailEn == null) //trường hợp null
            {
                CKEDITOR.instances['TxtDetailEn'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtDetailEn'].setData(data.DetailEn); //set dữ liệu Ckeditor
            }
            $('#SelectPriority option').removeAttr('selected').filter('[value=' + data.Priority + ']').attr('selected', true);

            $('#SelectCategory option').removeAttr('selected').filter('[value=' + data.GroupNewsCatTag + ']').attr('selected', true);
            //disabled danh mục
            $("#SelectCategory").attr('disabled', 'disabled');

                $("#Txtord").val(data.ord);

                $("#TxtNguon").val(data.Nguon);

                $("#CKActive").val(data.Active);
                if ($("#CKActive").val() == "1") {
                    $("#CKActive").prop('checked', true); // Checks it true
                    $("#CKActive").attr('checked', 'checked');
                }
                else {
                    $("#CKActive").prop('checked', false); // Checks it false
                    $("#CKActive").removeAttr('checked');
                }

                $("#TxtDescription").val(data.Description);

                $("#TxtKeyword").val(data.Keyword);

                $("#TxtImage").val(data.Image);
                $("#TxtImage1").val(data.Image1);
                $("#TxtImage2").val(data.Image2);
                $("#TxtImage3").val(data.Image3);
                $("#TxtImage4").val(data.Image4);
                $("#TxtImage5").val(data.Images5);

                // console.log(data);
                //load img envent main
                $("#imgShowScren").attr("src", data.Image); //lấy src trong data
                var img = $("#imgShowScren").attr("src"); // lấy giá trị
                if (img == "" || img == null) { //nếu null
                    $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
                }
                //load img envent SliedesShow 1
                $("#imgShowScren1").attr("src", data.Image1); //lấy src trong data
                var img1 = $("#imgShowScren1").attr("src"); // lấy giá trị
                if (img1 == "" || img1 == null) { //nếu null
                    $("#imgShowScren1").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
                }
                //load img envent SiledeShow 2
                $("#imgShowScren2").attr("src", data.Image2); //lấy src trong data
                var img2 = $("#imgShowScren2").attr("src"); // lấy giá trị
                if (img2 == "" || img2 == null) { //nếu null
                    $("#imgShowScren2").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
                }
                //load img envent SliedesShow 3
                $("#imgShowScren3").attr("src", data.Image3); //lấy src trong data
                var img3 = $("#imgShowScren3").attr("src"); // lấy giá trị
                if (img3 == "" || img3 == null) { //nếu null
                    $("#imgShowScren3").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
                }
                //load img envent SlidesShow 4
                $("#imgShowScren4").attr("src", data.Image4); //lấy src trong data
                var img4 = $("#imgShowScren4").attr("src"); // lấy giá trị
                if (img4 == "" || img4 == null) { //nếu null
                    $("#imgShowScren4").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
                }
                //load img envent SlidesShow 5
                $("#imgShowScren5").attr("src", data.Images5); //lấy src trong data
                var img5 = $("#imgShowScren5").attr("src"); // lấy giá trị
                if (img5 == "" || img5 == null) { //nếu null
                    $("#imgShowScren5").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
                }
         
            
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
