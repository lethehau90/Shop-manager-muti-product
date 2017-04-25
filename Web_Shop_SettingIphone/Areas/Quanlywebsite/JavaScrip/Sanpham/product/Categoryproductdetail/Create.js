function Insert() {
    var filter = window.location.search.substring(1); //lấy giá trị request url
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        Id: $("#TxtId").val(),
        Name: $("#TxtName").val(),
        NameEn: $('#TxtNameEn').val(),

        Tag: $("#TxtTag").val(),

        IDthuonghieu: "", //$("#TxtIDthuonghieu").val(),
        NguonSanPham: "", //$("#TxtINguonSanPham").val(),
        Mausac: "",//$("#TxtMausac").val(),
        Kichthuoc: "",//$("#TxtKichthuoc").val(),
        SanphamCungloai: "",
        Donvi: $("#TxtDonvi").val(),
        Luotdanhgia: "",
        Video: $("#TxtVideo").val(),

        Title: "",
        Description: $("#TxtDescription").val(),
        Keyword: $("#TxtKeyword").val(),

        Priority: $('#SelectPriority>option:selected').val(),//vị trí loại
        Index: "1",
        Order: $("#TxtOrder").val(),
        Active: "",

        GroupNewsCatTag: $('#SelectCategory>option:selected').val(),//id danh mục
        Cateprolevel1: "",
        Cateprolevel2: "",
        Cateprolevel3: "",

        Image: $("#TxtImage").val(),
        Image1: $("#TxtImage1").val(),
        Image2: $("#TxtImage2").val(),
        Image3: $("#TxtImage3").val(),
        Image4: $("#TxtImage4").val(),
        Image5: $("#TxtImage5").val(),

        Content: $("#TxtContent").val(),
        ContentEn: $('#TxtContentEn').val(),

        Detail: CKEDITOR.instances['TxtDetail'].getData(),
        DetailEn: CKEDITOR.instances['TxtDetailEn'].getData(),

        Khuyenmai: $("#TxtKhuyenmai").val(),
        KhuyenmaiEn: $('#TxtKhuyenmaiEn').val(),

        Baohanh: $("#TxtBaohanh").val(),
        BaohanhEn: $('#TxtBaohanhEn').val(),

        DacDiemNoiBat: CKEDITOR.instances['TxtDacDiemNoiBat'].getData(),
        DacDiemNoiBatEn: CKEDITOR.instances['TxtDacDiemNoiBatEn'].getData(),

        Thongdiep: $("#TxtThongdiep").val(),
        ThongdiepEn: $('#TxtThongdiepEn').val(),

        Seri: $('#TxtSeri').val(),
        Luotxem: "0",
        Soluongmua: "",
        DateCreate: "",
        DateView: "",

        //giá trị
        Stock: $('#SelectStock>option:selected').val(),
        Number_Stock: $('#TxtNumber_Stock').val(),
        Vat: "",
        Gianhaphang: $('#TxtGianhaphang').val(),
        Giaban: $('#TxtGiaban').val(),
        Phantramkhuyenmai: $('#TxtPhantramkhuyenmai').val(),
        Giabankhuyenmai: $('#TxtGiabankhuyenmai').val(),

        DateStart_Event: $('#datepickerDateStart_Event').val(),
        DateEnd_Event: $('#datepickerDateEnd_Event').val(),
        Giaban_Event: $('#TxtGiaban_Event').val(),
        Content_Event: $('#TxtContent_Event').val(),
        Content_EventEn: $('#TxtContent_EventEn').val(),

    };
    //thương hiệu
    var checkthuonghieu = $("input[name='Ck_IDthuonghieu']:checked");
    thuonghieus = [];
    for (var i = 0; i < checkthuonghieu.length; i++) {
        thuonghieus.push($(checkthuonghieu[i]).val());
    }
    var tmpthuonghieu = '';
    for (var i = 0 ; i < thuonghieus.length; i++) {
        tmpthuonghieu += thuonghieus[i] + ",";
    }
    object.IDthuonghieu = tmpthuonghieu.substring(0, tmpthuonghieu.length - 1);
    //màu sắc
    var checkmausac = $("input[name='Ck_Mausac']:checked");
    mausacs = [];
    for (var i = 0; i < checkmausac.length; i++) {
        mausacs.push($(checkmausac[i]).val());
    }
    var tmpmausac = '';
    for (var i = 0 ; i < mausacs.length; i++) {
        tmpmausac += mausacs[i] + ",";
    }
    object.Mausac = tmpmausac.substring(0, tmpmausac.length - 1);

    //Kich thuoc
    var checkkichthuoc = $("input[name='Ck_Kichthuoc']:checked");
    kichthuocs = [];
    for (var i = 0; i < checkkichthuoc.length; i++) {
        kichthuocs.push($(checkkichthuoc[i]).val());
    }
    var tmpkichthuoc = '';
    for (var i = 0 ; i < kichthuocs.length; i++) {
        tmpkichthuoc += kichthuocs[i] + ",";
    }
    object.Kichthuoc = tmpkichthuoc.substring(0, tmpkichthuoc.length - 1);

    //NguonSanPham
    var checknguonSanPham = $("input[name='Ck_NguonSanPham']:checked");
    NguonSanPhams = [];
    for (var i = 0; i < checknguonSanPham.length; i++) {
        NguonSanPhams.push($(checknguonSanPham[i]).val());
    }
    var tmpNguonSanPham = '';
    for (var i = 0 ; i < NguonSanPhams.length; i++) {
        tmpNguonSanPham += NguonSanPhams[i] + ",";
    }
    object.NguonSanPham = tmpNguonSanPham.substring(0, tmpNguonSanPham.length - 1);

    //SanphamCungloai
    var checkSanphamCungloai = $("input[name='Ck_Sanphamcungloai']:checked");
    SanphamCungloais = [];
    for (var i = 0; i < checkSanphamCungloai.length; i++) {
        SanphamCungloais.push($(checkSanphamCungloai[i]).val());
    }
    var tmpSanphamCungloai = '';
    for (var i = 0 ; i < SanphamCungloais.length; i++) {
        tmpSanphamCungloai += SanphamCungloais[i] + ",";
    }
    object.SanphamCungloai = tmpSanphamCungloai.substring(0, tmpSanphamCungloai.length - 1);


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

    var check = $("#CKVat:checked").val();
    if (check == "1") {
        object.Vat = true; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Vat = false; //gán giá trị 0 (false) không kích hoạt
    }

    if (object.Name == null || object.Name == "") {
        var html = "<span  class='error'>Tên danh mục (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtName").parent().append(html);
        flag = false;
    }
    if (object.Content == null || object.Content == "") {
        var html = "<span  class='error'>mô tả bài viết (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtContent").parent().append(html);
        flag = false;
    }
    if (CKEDITOR.instances['TxtDetail'].getData() == null || CKEDITOR.instances['TxtDetail'].getData() == "") {
        var html = "<span  class='error'>Chi tiết nội dung (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $(".TxtDetail").parent().append(html);
        flag = false;
    }
    if (object.Order == null || object.Order == "") {
        var html = "<span  class='error'></br> Số thứ tự (không bỏ trống)</span>";
        $("#TxtOrder").parent().append(html);
        flag = false;
    }

    if (object.Number_Stock == null || object.Number_Stock == "") {
        var html = "<span  class='error'>Số lượng tồn(không bỏ trống)</span>";
        $(".TxtNumber_Stock").html(html);
        flag = false;
    }
    if (object.Gianhaphang == null || object.Gianhaphang == "") {
        var html = "<span  class='error'> Giá nhập hàng (không bỏ trống)</span>";
        $(".TxtGianhaphang").html(html);
        flag = false;
    }
    if (object.Giaban == null || object.Giaban == "") {
        var html = "<span  class='error'> Giá bán hàng (không bỏ trống)</span>";
        $(".TxtGiaban").html(html);
        flag = false;
    }
    if (object.Phantramkhuyenmai == null || object.Phantramkhuyenmai == "") {
        var html = "<span  class='error'> % khuyến mãi (không bỏ trống)</span>";
        $(".TxtPhantramkhuyenmai").html(html);
        flag = false;
    }
    if (object.Giabankhuyenmai == null || object.Giabankhuyenmai == "") {
        var html = "<span  class='error'> Giá khuyến mãi (không bỏ trống)</span>";
        $(".TxtGiabankhuyenmai").html(html);
        flag = false;
    }

    if (object.GroupNewsCatTag == null || object.GroupNewsCatTag == "") {
        var html = "<span  class='error'> Danh mục chưa được chọn</span>";
        $("#SelectCategory").parent().append(html);
        flag = false;
    }
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
                url: "/Quanlywebsite/CategotyproductdetailAdmin/Insert",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if(data ==1 || data ==0 || data ==3)
                    {
                        if (data == 1) {
                            alert_Insert(); //thông báo
                            window.setTimeout(function () {
                                location.href = "/Quanlywebsite/CategotyproductdetailAdmin/Read?" + filter;
                            }, 2000)
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