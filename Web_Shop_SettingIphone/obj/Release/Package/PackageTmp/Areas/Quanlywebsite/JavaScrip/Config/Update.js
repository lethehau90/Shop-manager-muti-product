function Upadte() {
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = {
            Id: 1,
            Mail_Smtp:  $("#TxtMail_Smtp").val(),
            Mail_Port:  $("#TxtMail_Port").val(),
            Mail_Info:$("#TxtMail_Info").val(),
            Mail_Noreply:$("#TxtMail_Noreply").val(),
            Mail_Password: $("#TxtMail_Password").val(),
            PlaceHead: $("#TxtPlaceHead").val(),

            PlaceBody: CKEDITOR.instances['TxtPlaceBody'].getData(),

            GoogleId  :$("#TxtGoogleId").val(),
            Contact: $("#TxtContact").val(),

            DeliveryTerms: CKEDITOR.instances['TxtDeliveryTerms'].getData(), //get dữ liệu ckeditor
            PaymentTerms: CKEDITOR.instances['TxtPaymentTerms'].getData(),

            FreeShipping :$("#TxtFreeShipping").val(),

            Copyright: CKEDITOR.instances['TxtCopyright'].getData(),

            Title :$("#TxtTitle").val(),
            Description :$("#TxtDescription").val(),
            Keyword:$("#TxtKeyword").val(),
            Lang: $("#TxtLang").val(),

            Helpsize: CKEDITOR.instances['TxtHelpsize'].getData(),

            Location: $("#TxtLocation").val(),

            ToolScrip: CKEDITOR.instances['TxtToolScrip'].getData(),

            Icon: $("#TxtIcon").val(),
            pageging1: $("#pageging1").val(),
            pageging2: $("#pageging2").val(),
            pageging3: $("#pageging3").val(),
            pageging4: $("#pageging4").val(),
            pageging5: $("#pageging5").val(),
            Map: CKEDITOR.instances['TxtMap'].getData()
    };
    

   
    $.each(object, function (key, item) { //lặp key xử lý

        if (key == "Title" || key == "Description" || key == "Keyword" || key == "Icon") // kiểm tra dữ liệu đầu vào
        {
            if(item=="")
            {
                var html = "<span style='color:red' class='error'>Vui lòng nhập trường này(bắt buộc)</span>";
                $("#Txt" + key).parent().append(html); //xuất html phái sau text
                flag = false;
            }
        }
        if( key== "Mail_Port")
        {
            if(item=="" || item==null)
            {
                object.Mail_Port = 0;
            }
        }
      
    });
    if (flag == true) { //trạng thái đúng bắt đầu xử lý
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            $("body").removeClass("loading");
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/ConfigAdmin/Update",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0) {
                        if (data == 1) {
                            alert_update(); //thông báo
                            window.setTimeout(function () {
                              
                                location.href = "/Quanlywebsite/ConfigAdmin/Read";
                               
                            }, 2000)
                           
                        }
                        else {
                            alert_name();
                            return false;
                        }
                    }
                    else {
                        alert_Role();
                    }
                },
                error: function (err) {
                    alert("Error:" + err.responseText);
                }
            });

            $("body").removeClass("loading");
        }, 1000);
    }
    else {
        alert_question_libary();

    }
    return flag;

}