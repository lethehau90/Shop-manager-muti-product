function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/Tax_rulerAdmin/Get_Read',
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
            $("#TxtProvince").val(data.Province);
            $("#TxtTax_pri").val(data.Tax_pri);
            $("#File_tax").val(data.File_tax);
            $("#TxtOrd").val(data.Ord);
            $("#TxtNameEn").val(data.NameEn);
         
            if (data.Description == null) //trường hợp null
            {
                CKEDITOR.instances['TxtDescription'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtDescription'].setData(data.Description); //set dữ liệu Ckeditor
            }

            if (data.DescriptionEn == null) //trường hợp null
            {
                CKEDITOR.instances['DescriptionEn'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['DescriptionEn'].setData(data.DescriptionEn); //set dữ liệu Ckeditor
            }

           

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

           
         
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
