function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/ConfigAdmin/Get_Read',
        type: "Post",
        dataType: 'json',
        data: { Id: Id },
        success: function (data) {

            $("#TxtId").val(data.Id);
            $("#TxtMail_Smtp").val(data.Mail_Smtp);
            $("#TxtMail_Port").val(data.Mail_Port);
            $("#TxtMail_Info").val(data.Mail_Info);
            $("#TxtMail_Noreply").val(data.Mail_Noreply);
            $("#TxtMail_Password").val(data.Mail_Password);
            $("#TxtPlaceHead").val(data.PlaceHead);


            $("#TxtCopyright").val(data.Copyright);
            $("#TxtTitle").val(data.Title);
            $("#TxtDescription").val(data.Description);
            $("#TxtKeyword").val(data.Keyword);
            $("#TxtLang").val(data.Lang);
            $("#TxtHelpsize").val(data.Helpsize);

            $("#TxtPlaceBody").val(data.PlaceBody);
            $("#TxtGoogleId").val(data.GoogleId);
            $("#TxtContact").val(data.Contact);
            $("#TxtDeliveryTerms").val(data.DeliveryTerms);
            $("#TxtPaymentTerms").val(data.PaymentTerms);
            $("#TxtFreeShipping").val(data.FreeShipping);

            $("#pageging1").val(data.pageging1); 
            $("#pageging2").val(data.pageging2);
            $("#pageging3").val(data.pageging3);
            $("#pageging4").val(data.pageging4);
            $("#pageging5").val(data.pageging5);

       

            $("#TxtLocation").val(data.Location);
            $("#TxtToolScrip").val(data.ToolScrip);
            $("#TxtIcon").val(data.Icon);
            $("#TxtMap").val(data.Map);

            //load img sự kiện hình ảnh

            $("#imgShowScren").attr("src", data.Icon); //lấy src trong data
            var img = $("#imgShowScren").attr("src"); // lấy giá trị
            if (img == "" || img==null) { //nếu null
                $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
            }
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}

