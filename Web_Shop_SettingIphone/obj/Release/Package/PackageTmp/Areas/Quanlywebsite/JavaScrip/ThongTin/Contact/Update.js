function Upadte() {
    var url = window.location.href;
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        Id:$("#TxtId").val(),
        Name: $("#TxtName").val(),
        Company: $("#TxtCompany").val(),
        Address: $("#TxtAddress").val(),
        Tel: $("#TxtTel").val(),
        Mail: $("#TxtMail").val(),
        Detail: CKEDITOR.instances['TxtDetail'].getData(),
        Date:"",
        Active: "",
        Lang: "vi",
        NameEn: "",
        CompanyEn: "",
        AddressEn: "",
        DetailEn: ""
     
    };

    // console.log(object);
    // return false;
    // đưa giá trị actice chek
    var check = $("#CKActive:checked").val();
    if (check == "1") {
        object.Active = "1"; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Active = "0"; //gán giá trị 0 (false) không kích hoạt
    }

  
    if (flag == true) { //trạng thái đúng bắt đầu xử lý
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            $("body").removeClass("loading");
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/ContactAdmin/Update",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0) {
                        if (data == 1) {
                            alert_update(); //thông báo
                            window.setTimeout(function () {
                              
                                location.href = url;
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