function Insert() {
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        //Id_quantity: $("#TxtId").val(),
        Sl_mua: $("#TxtSl_mua").val(),
        Phan_tram_tang: $("#TxtPhan_tram_tang").val(),
        Active: "",
    };

    // console.log(object);
    // return false;
    // đưa giá trị actice chek
    var check = $("#CKActive:checked").val();
    if (check == "1") {
        object.Active = true; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Active = false; //gán giá trị 0 (false) không kích hoạt
    }

    if (object.Sl_mua == null || object.Sl_mua == "") {
        var html = "<span  class='error'>yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtSl_mua").parent().append(html);
        flag = false;
    }
    if (object.Phan_tram_tang == null || object.Phan_tram_tang == "") {
        var html = "<span  class='error'>yêu cầu nhập (không bỏ trống)</span>";
        $(".TxtPhan_tram_tang").parent().append(html);
        flag = false;
    }
    
    if (flag == true) //trang thái đúng bắt đầu xử lý
    {
        //console.log(object); //bug lỗi
       // return false;
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/KM_SoluongmuahangAdmin/Insert",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if(data ==1 || data ==0)
                    {
                        if (data == 1) {
                            alert_Insert(); //thông báo
                            window.setTimeout(function () {
                                location.href = "/Quanlywebsite/KM_SoluongmuahangAdmin/Read";
                            }, 2000)
                        }
                        else {
                            alert_sl();
                            return false;
                        }
                    }
                    else
                    {
                        alert_Role();
                    }
                },
                error: function (err) {
                    alert("Error:" + err.responseText);
                }
            });
           
            $("body").removeClass("loading");
        }, 1000); //end loading
    }
    else {
        alert_question_libary();

    }
    return flag;

}