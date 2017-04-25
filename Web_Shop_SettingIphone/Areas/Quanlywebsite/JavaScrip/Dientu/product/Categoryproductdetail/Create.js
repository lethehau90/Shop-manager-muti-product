function Insert() {
    var filter = window.location.search.substring(1); //lấy giá trị request url
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        Seri: $("#TxtSeri").val(),
        Tenhang: $("#TxtTenhang").val(),

        Img: $("#TxtImage").val(),
        ThumImg: "", 
        Thum_img_img: "", 
        Idnsx: $('#Selecthsx>option:selected').val(),
        Giaban: $("#TxtGiaban").val(),
        Giamua: "0",
        Soluong: "0",
        Tinhtrang: $('#Selecttinhtrang>option:selected').val(),
        Donvi: "",

        Baohanh: $("#TxtBaohanh").val(),
        Ngaynhap: null,
        Danhgia: "0",
        Luotxem: "0",
        Vat: "0",
        Lienhe: "",
        Forder:"",

        Baiviet: CKEDITOR.instances['TxtBaiviet'].getData(),
        Thongso: "",

        Mota: CKEDITOR.instances['TxtMota'].getData(),
        Giagiam: "0",
        Phantramkm: "0",
        Title: "",

        Keyword: $("#TxtKeyword").val(),
        Description: $("#TxtDescription").val(),
        Khuvuc: "",
        thuoctinh: "",

        khuyenmai: "",
        khuyenmai_html: CKEDITOR.instances['Txtkhuyenmai_html'].getData(),
        Ord: $("#TxtOrd").val(),
        Active: "",
        Idmenu: $('#SelectCategory>option:selected').val(),
        Priority: $('#SelectPriority>option:selected').val(),

        Index:"0",
        Idthuoctinh: "0",

        Diemdanhgia: "0",
        Ngayxemganday: null,

        Tag: "",
        GroupNewsCatTag: $('#SelectCategory>option:selected').val(),

        Cateprolevel1: "",
        Cateprolevel2: "",

        Cateprolevel3: "",

        //Thuoc tinh
        IdLoaiThuoctinh: $('#Selectloaithuoctinh>option:selected').val(),//thuộc tính,
        IdCapLoaiThuoctinh: $('#Selectcapthuoctinh>option:selected').val(),//thuộc tính,
        NameTT: $("#TxtNameTT").val(),
        ValueTT: $("#TxtValueTT").val()
        

    };
        object.Tag = change_alias(object.Tenhang);
    //console.log(object);
    //return false;
    // đưa giá trị actice chek
    var check = $("#CKActive:checked").val();
    if (check == "1") {
        object.Active = 1; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Active = 0; //gán giá trị 0 (false) không kích hoạt
    }

    //var check = $("#CKVat:checked").val();
    //if (check == "1") {
    //    object.Vat = true; //gán giá trị 1 (true) có kích hoạt
    //}
    //else {
    //    object.Vat = false; //gán giá trị 0 (false) không kích hoạt
    //}

    if (object.Tenhang == null || object.Tenhang == "") {
        var html = "<span  class='error'>Tên danh mục  yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtTenhang").parent().append(html);
        flag = false;
    }
    if (CKEDITOR.instances['TxtMota'].getData() == null || CKEDITOR.instances['TxtMota'].getData() == "") {
        var html = "<span  class='error'>Mô tả nội dung yêu cầu nhập (không bỏ trống)</span>";
        $(".TxtMota").parent().append(html);
        flag = false;
    }
    if (CKEDITOR.instances['TxtBaiviet'].getData() == null || CKEDITOR.instances['TxtBaiviet'].getData() == "") {
        var html = "<span  class='error'>Chi tiết nội dung yêu cầu nhập (không bỏ trống)</span>";
        $(".TxtBaiviet").parent().append(html);
        flag = false;
    }
    if (object.Ord == null || object.Ord == "") {
        var html = "<span  class='error'></br> Số thứ tự (không bỏ trống)</span>";
        $("#TxtOrd").parent().append(html);
        flag = false;
    }
    if (object.Baohanh == null || object.Baohanh == "") {
        var html = "<span  class='error'></br> Bảo hành (không bỏ trống)</span>";
        $("#TxtBaohanh").parent().append(html);
        flag = false;
    }
    if (object.Idmenu == null || object.Idmenu == "") {
        var html = "<span  class='error'> Danh mục chưa được chọn</span>";
        $("#SelectCategory").parent().append(html);
        flag = false;
    }
    if (object.Idthuoctinh == null || object.Idthuoctinh == "") {
        var html = "<span  class='error'> Danh mục chưa được chọn</span>";
        $("#Selectthuoctinh").parent().append(html);
        flag = false;
    }
    if (object.Idnsx == null || object.Idnsx == "") {
        var html = "<span  class='error'> Danh mục chưa được chọn</span>";
        $("#Selecthsx").parent().append(html);
        flag = false;
    }
    //thuộc tính
    //if (object.IdLoaiThuoctinh == null || object.IdLoaiThuoctinh == "") {
    //    var html = "<span  class='error'> (không bỏ trống)</span>";
    //    $("#Selectloaithuoctinh").parent().append(html);
    //    flag = false;
    //}
    //if (object.IdCapLoaiThuoctinh == null || object.IdCapLoaiThuoctinh == "") {
    //    var html = "<span  class='error'> (không bỏ trống)</span>";
    //    $("#Selectcapthuoctinh").parent().append(html);
    //    flag = false;
    //}
    //if (object.NameTT == null || object.NameTT == "") {
    //    var html = "<span  class='error'> (không bỏ trống)</span>";
    //    $("#TxtNameTT").parent().append(html);
    //    flag = false;
    //}
    //if (object.ValueTT == null || object.ValueTT == "") {
    //    var html = "<span  class='error'> (không bỏ trống)</span>";
    //    $("#TxtValueTT").parent().append(html);
    //    flag = false;
    //}
    //if (object.Image == null || object.Image == "") {
    //    var html = "<span  class='error'>hình ảnh rỗng (không bỏ trống)</span>";
    //    $("#TxtImage").parent().append(html);
    //    flag = false;
    //}
   
    if (flag == true) //trang thái đúng bắt đầu xử lý
    {
        //console.log(object); //bug lỗi
       // return false;
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/DientuMathangAdmin/Insert",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if(data ==1 || data ==0 || data ==3)
                    {
                        if (data == 1) {
                            alert_thuoctinh(); //thông báo
                            window.setTimeout(function () {
                                //  location.href = "/Quanlywebsite/DientuMathangAdmin/Read?" + filter;

                                Get_Read_Tag(object.Tag);
                                //trượt tới vị trí panner
                                $('html, body').animate({
                                    scrollTop: $("#update_paner").offset().top
                                }, 500);
                            }, 1000)
                        }
                        else if( data ==3)
                        {
                            alert_date();
                            return false;
                        }
                        else {
                            alert_name();
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