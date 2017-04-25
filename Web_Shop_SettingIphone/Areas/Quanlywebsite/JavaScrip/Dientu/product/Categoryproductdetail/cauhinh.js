$(document).ready(function () {
    $("#saveCH").click(function () {
        $("body").addClass("loading");
        setTimeout(function () {

            var Idproduct = $("#TxtId").val();
            if (Idproduct == "") {
                InsertMain();

            }
            else {
                $(".cauhinhtab").removeClass("hidden");
                var IdTagCH = $("#IdTagCH").val();
                if (IdTagCH == "") {
                    insertCH();
                }
                else {
                    updateCH();
                }
            }


            $("body").removeClass("loading");
        }, 500);
        
    });
});

$(".cauhinhtab").addClass("hidden");

function getloadcauhinh(Idproduct) {
    $.ajax({
        type: "GET",
        url: "/Quanlywebsite/DientuChitiethinhAdmin/Get_ReadCH",
        data: { Idproduct: Idproduct },
        dataType: "json",
        success: function (data) {
            var html = '';
            if (data.length > 0) {
                html += '<div class="panel-body-thuoctinh">';
                html += '<table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example">';
                html += '<thead>';
                html += '<tr>';
                html += '<th>Ảnh</th>';
                html += '<th>Màu</th>';
                html += '<th>Số lượng</th>';
                html += '<th>Giá cũ</th>';
                html += '<th>Giá bán</th>';
                html += '<th>% KM</th>';
                html += '<th>Tình trạng</th>';
                html += '<th>Sắp xếp</th>';
                html += '<th>Kích hoạt</th>';
                html += '<th>Chức năng</th>';
                html += '</tr>';
                html += '<thead>';
                html += '<tbody>';
                $.each(data, function (key, item) {
                    //active
                    var activestring = "";
                    if (item.Active == true) {
                        activestring = "Có";
                    }
                    else activestring = "Không";
                    //tình trạng
                    var tinhtrangstring = "";
                    if (item.Tinhtrang == 1) {
                        tinhtrangstring = "Còn hàng";
                    }
                    else tinhtrangstring = "hết hàng";
                    html += '<tr class="odd gradeX">';
                    html += '<td><img src="' + item.Images + '" class="imglogo ShowImgZoom img-responsive"></td>';
                    html += '<td>' + item.Tenmau + '</td>';
                    html += '<td>' + item.Soluong + '</td>';
                    html += '<td>' + formatMoneyVND(item.Giacu) + '</td>';
                    html += '<td>' + formatMoneyVND(item.Giaban) + '</td>';
                    html += '<td>' + item.Phantramkm + '%</td>';
                    html += '<td>' + tinhtrangstring + '</td>';
                    html += '<td>' + item.Ord + '</td>';
                    html += '<td>';
                    html += '<a class="label label-primary btn-active" id="btn-activett" onclick="return activech(' + "'" + item.IdTag + "'" + ')">';
                    html += "<strong>" + activestring + "</strong>";
                    html += "</a>";
                    html += "</td>";
                    html += '<td class="function">';
                    html += '<a class="btn btn-info btn-xs Edit Edit-thuoctinh" onclick="return ClickEditCH(' + "'" + item.IdTag + "'" + ')" data-id="' + item.Id + '" id="Delete"><i class="fa fa-trash-o"></i> Edit </a>';
                    html += '<a class="btn btn-danger btn-xs Delete-thuoctinh" onclick="return ClickDeleteCH(' + "'" + item.IdTag + "'" + ')" data-id="' + item.Id + '" id="Delete"><i class="fa fa-trash-o"></i> Delete </a>';
                    html += '</td>';
                    html += '</tr>';
                });
                html += ' </tbody>';
                html += '</table>';
                html += '</div>';
            }
            else {
                var html = '<b>Chưa có cấu hình nào</b>';
            }


            $("#Idcauhinhthietlap").html(html);

        },
        error: function (ex) {
            alert("Da co loi xay ra" + ex.responseText);
        }
    });
}

function insertCH() {
    var filter = window.location.search.substring(1); //lấy giá trị request url
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    var IdPR = $("#TxtId").val();
    var objectCH = {
        //Thuoc tinh
        IdProduct: $("#TxtId").val(),
        Images: $("#TxtImageCH").val(), 
        ThumImg:"",
        Idmau: $('#SelectmausacCH>option:selected').val(),
        Iddungluong: $('#SelectIddungluongCH>option:selected').val(),
        IdSize:"",
        Giaban: $("#TxtGiabanCH").val(),
        Giacu: $("#TxtGiacuCH").val(),
        Soluong: $("#TxtSoluongCH").val(),
        Phantramkm: $("#TxtPhantramkmCH").val(),
        Tinhtrang: $('#SelectTinhtrangCH>option:selected').val(),
        Ord: $("#TxtOrdCH").val(),
        Active: "",
        IdTag: "",
        Images1: $("#TxtImage1CH").val(),
        Images2: $("#TxtImage2CH").val(),
        Images3: $("#TxtImage3CH").val(),
        Images4: $("#TxtImage4CH").val()
    }
    var check = $("#CKActiveCH:checked").val();
    if (check == "1") {
        objectCH.Active = true; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        objectCH.Active = false; //gán giá trị 0 (false) không kích hoạt
    }
    if (objectCH.Ord == null || objectCH.Ord == "") {
        var html = "<span  class='error'></br>(không bỏ trống)</span>";
        $("#TxtOrdCH").parent().append(html);
        flag = false;
    }
    if (objectCH.Images == null || objectCH.Images == "") {
        var html = "<span  class='error'></br>(không bỏ trống)</span>";
        $("#TxtImageCH").parent().append(html);
        flag = false;
    }
    if (objectCH.Phantramkm == null || objectCH.Phantramkm == "") {
        var html = "<span  class='error'></br>(không bỏ trống)</span>";
        $("#TxtPhantramkmCH").parent().append(html);
        flag = false;
    }
    //thuộc tính
    if (objectCH.Idmau == null || objectCH.Idmau == "") {
        var html = "<span  class='error'> (không bỏ trống)</span>";
        $("#SelectmausacCH").parent().append(html);
        flag = false;
    }
    //dung lượng
    if (objectCH.Iddungluong == null || objectCH.Iddungluong == "") {
        var html = "<span  class='error'> (không bỏ trống)</span>";
        $("#SelectIddungluongCH").parent().append(html);
        flag = false;
    }
    $.each(objectCH, function (key, item) { //process delete
        if( $("#Txt" + key+"CH").val() == "")
        {
            var html = "<span  class='error'> (không bỏ trống)</span>";
            $(".Txt" + key + "CH").append(html);
            flag = false;
        }
    });
    if (flag == true) //trang thái đúng bắt đầu xử lý
    {
        //console.log(object); //bug lỗi
        // return false;
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/DientuChitiethinhAdmin/Insert",
                type: "Post",
                data: objectCH,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0 || data == 3) {
                        if (data == 1) {
                            // alert_Insert(); //thông báo
                            getloadcauhinh($("#TxtId").val());
                            cancelCH();
                            alert_updatesuccess();
                        }
                        else if (data == 3) {
                            alert_date();
                            return false;
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
        }, 1000); //end loading
    }
    else {
        alert_question_libary();

    }
}

function updateCH() {
    var filter = window.location.search.substring(1); //lấy giá trị request url
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    var IdPR = $("#TxtId").val();
    var objectCH = {
        //Thuoc tinh
        IdTag: $("#IdTagCH").val(),
        IdProduct: $("#TxtId").val(),
        Images: $("#TxtImageCH").val(),
        ThumImg: "",
        Idmau: $('#SelectmausacCH>option:selected').val(),
        Iddungluong: $('#SelectIddungluongCH>option:selected').val(),
        IdSize: "",
        Giaban: $("#TxtGiabanCH").val(),
        Giacu: $("#TxtGiacuCH").val(),
        Soluong: $("#TxtSoluongCH").val(),
        Phantramkm: $("#TxtPhantramkmCH").val(),
        Tinhtrang: $('#SelectTinhtrangCH>option:selected').val(),
        Ord: $("#TxtOrdCH").val(),
        Active: "",
        Images1: $("#TxtImage1CH").val(),
        Images2: $("#TxtImage2CH").val(),
        Images3: $("#TxtImage3CH").val(),
        Images4: $("#TxtImage4CH").val()
    }
    var check = $("#CKActiveCH:checked").val();
    if (check == "1") {
        objectCH.Active = true; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        objectCH.Active = false; //gán giá trị 0 (false) không kích hoạt
    }
    if (objectCH.Ord == null || objectCH.Ord == "") {
        var html = "<span  class='error'></br>(không bỏ trống)</span>";
        $("#TxtOrdCH").parent().append(html);
        flag = false;
    }
    if (objectCH.Images == null || objectCH.Images == "") {
        var html = "<span  class='error'></br>(không bỏ trống)</span>";
        $("#TxtImageCH").parent().append(html);
        flag = false;
    }
    if (objectCH.Phantramkm == null || objectCH.Phantramkm == "") {
        var html = "<span  class='error'></br>(không bỏ trống)</span>";
        $("#TxtPhantramkmCH").parent().append(html);
        flag = false;
    }
    //thuộc tính
    if (objectCH.Idmau == null || objectCH.Idmau == "") {
        var html = "<span  class='error'> (không bỏ trống)</span>";
        $("#SelectmausacCH").parent().append(html);
        flag = false;
    }
    //dung lượng
    if (objectCH.Iddungluong == null || objectCH.Iddungluong == "") {
        var html = "<span  class='error'> (không bỏ trống)</span>";
        $("#SelectIddungluongCH").parent().append(html);
        flag = false;
    }
    $.each(objectCH, function (key, item) { //process delete
        if ($("#Txt" + key + "CH").val() == "") {
            var html = "<span  class='error'> (không bỏ trống)</span>";
            $(".Txt" + key + "CH").append(html);
            flag = false;
        }
    });
    if (flag == true) //trang thái đúng bắt đầu xử lý
    {
        //console.log(object); //bug lỗi
        // return false;
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/DientuChitiethinhAdmin/Update",
                type: "Post",
                data: objectCH,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0 || data == 3) {
                        if (data == 1) {
                            // alert_Insert(); //thông báo
                            getloadcauhinh($("#TxtId").val());
                            cancelCH();
                            alert_updatesuccess();
                        }
                        else if (data == 3) {
                            alert_date();
                            return false;
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
        }, 1000); //end loading
    }
    else {
        alert_question_libary();

    }
}

function cancelCH()
{
    $("#IdTagCH").val("");
    $("#TxtImageCH").val("");
    $("#TxtGiacuCH").val("");
    $("#TxtGiabanCH").val("");
    $("#TxtPhantramkmCH").val("0");
    $("#TxtSoluongCH").val("1");
    $('#SelectTinhtrangCH option').removeAttr('selected').filter('[value=1]').attr('selected', true);
    $('#SelectmausacCH option').removeAttr('selected').filter('[value=""]').attr('selected', true);
    $('#SelectIddungluongCH option').removeAttr('selected').filter('[value=""]').attr('selected', true);
    $("#TxtOrdCH").val("");
    $("#CKActiveCH").prop('checked', true); // Checks it true
    $("#CKActiveCH").attr('checked', 'checked');

    $("#TxtImage1CH").val("");
    $("#TxtImage2CH").val("");
    $("#TxtImage3CH").val("");
    $("#TxtImage4CH").val("");

    var img = $("#imgShowScren").attr("src"); // lấy giá trị
    if (img == "" || img == null) { //nếu null
        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
    }
}
