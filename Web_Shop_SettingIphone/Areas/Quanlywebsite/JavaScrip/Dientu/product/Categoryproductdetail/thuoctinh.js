$(document).ready(function () {
    $("#saveTT").click(function () {
        var Idproduct = $("#TxtId").val();
        if(Idproduct =="")
        {
            InsertMain();
          
        }
        else
        {
            var IdTagTT=   $("#IdTagTT").val();
            $(".thuoctinhtab").removeClass("hidden");
            if(IdTagTT =="")
            {
                insertTT();
            }
            else
            {
                updateTT();
            }
        }
    });
});

$(".thuoctinhtab").addClass("hidden");


function getloadthuoctinh(Idproduct) {
    $.ajax({
        type: "GET",
        url: "/Quanlywebsite/DientuThuoctinhAdmin/ReadTT",
        data: { Idproduct: Idproduct },
        dataType: "json",
        success: function (data) {
            var html = '';
            if (data.length > 0)
            {
                html += '<div class="panel-body-thuoctinh">';
                html += '<table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example">';
                html += '<thead>';
                html += '<tr>';
                html += '<th>Tên</th>';
                html += '<th>Thuộc tính</th>';
                //html += '<th>Phân loại</th>';
               // html += '<th>Nhóm loại</th>';
                html += '<th>Sắp xếp</th>';
                html += '<th>Kích hoạt</th>';
                html += '<th>Chức năng</th>';
                html += '</tr>';
                html += '<thead>';
                html += '<tbody>';
                $.each(data, function (key, item) {
                    var activestring = "";
                    if (item.Active == true) {
                        activestring = "Có";
                    }
                    else activestring = "Không";
                    html += '<tr class="odd gradeX">';
                    html += '<td>' + item.Text + '</td>';
                    html += '<td>' + item.Value + '</td>';
                   // html += '<td>' + item.Name + '</td>'; //Name là phân loại thuộc tính
                   // html += '<td>' + item.Expr1 + '</td>'; //Expr1 Nhóm phân loại thuộc tính
                    html += '<td>' + item.Ord + '</td>';
                    html += '<td>';
                    html += '<a class="label label-primary btn-active" id="btn-activett" onclick="return activett(' + "'" + item.IdTag + "'" + ')">';
                    html += "<strong>" + activestring + "</strong>";
                    html += "</a>";
                    html += "</td>";
                    html += '<td class="function">';
                    html += '<a class="btn btn-info btn-xs Edit Edit-thuoctinh" onclick="return ClickEditTT(' + "'" + item.IdTag + "'" + ')" data-id="' + item.Id + '" id="Delete"><i class="fa fa-trash-o"></i> Edit </a>';
                    html += '<a class="btn btn-danger btn-xs Delete-thuoctinh" onclick="return ClickDeleteTT(' + "'" + item.IdTag + "'" + ')" data-id="' + item.Id + '" id="Delete"><i class="fa fa-trash-o"></i> Delete </a>';
                    html += '</td>';
                    html += '</tr>';
                });
                html += ' </tbody>';
                html += '</table>';
                html += '</div>';
            }
            else {
                var html = '<b>Chưa có thuộc tính nào</b>';
            }
            

            $("#Idthuoctinhthietlap").html(html);

        },
        error: function (ex) {
            alert("Da co loi xay ra" + ex.responseText);
        }
    });
}


function insertTT() {
    var filter = window.location.search.substring(1); //lấy giá trị request url
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    var IdPR = $("#TxtId").val();
    var object = {
        //Thuoc tinh
        Idthuoctinh: "1",// $('#Selectloaithuoctinh>option:selected').val(),//thuộc tính,
        Idcapthuoctinh: "1", //$('#Selectcapthuoctinh>option:selected').val(),//thuộc tính,
        Idproduct: $("#TxtId").val(),
        Text: $("#TxtNameTT").val(),
        Value: $("#TxtValueTT").val(),
        Ord: $("#TxtOrdTT").val(),
        Active: "",
        TagProduct: "",
        Content: ""
    }
    var check = $("#CKActiveTT:checked").val();
    if (check == "1") {
        object.Active = true; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Active = false; //gán giá trị 0 (false) không kích hoạt
    }
    if (object.Ord == null || object.Ord == "") {
        var html = "<span  class='error'></br>(không bỏ trống)</span>";
        $("#TxtOrdTT").parent().append(html);
        flag = false;
    }
    //thuộc tính
    if (object.Idthuoctinh == null || object.Idthuoctinh == "") {
        var html = "<span  class='error'> (không bỏ trống)</span>";
        $("#Selectloaithuoctinh").parent().append(html);
        flag = false;
    }
    if (object.Idcapthuoctinh == null || object.Idcapthuoctinh == "") {
        var html = "<span  class='error'> (không bỏ trống)</span>";
        $("#Selectcapthuoctinh").parent().append(html);
        flag = false;
    }
    if (object.Text == null || object.Text == "") {
        var html = "<span  class='error'> (không bỏ trống)</span>";
        $("#TxtNameTT").parent().append(html);
        flag = false;
    }
    if (object.Value == null || object.Value == "") {
        var html = "<span  class='error'> (không bỏ trống)</span>";
        $("#TxtValueTT").parent().append(html);
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
                url: "/Quanlywebsite/DientuThuoctinhAdmin/Insert",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0 || data == 3) {
                        if (data == 1) {
                           // alert_Insert(); //thông báo
                            window.setTimeout(function () {
                                getloadthuoctinh($("#TxtId").val());
                                cancelTT();
                            }, 500)
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

function updateTT() {
    var filter = window.location.search.substring(1); //lấy giá trị request url
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    var IdPR = $("#TxtId").val();
    var object = {
        //Thuoc tinh
        IdTag: $("#IdTagTT").val(),
        Idthuoctinh: "1",// $('#Selectloaithuoctinh>option:selected').val(),//thuộc tính,
        Idcapthuoctinh: "1", //$('#Selectcapthuoctinh>option:selected').val(),//thuộc tính,
        Idproduct: $("#TxtId").val(),
        Text: $("#TxtNameTT").val(),
        Value: $("#TxtValueTT").val(),
        Ord: $("#TxtOrdTT").val(),
        Active: "",
        TagProduct: "",
        Content: ""
    }
    var check = $("#CKActiveTT:checked").val();
    if (check == "1") {
        object.Active = true; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Active = false; //gán giá trị 0 (false) không kích hoạt
    }
    if (object.Ord == null || object.Ord == "") {
        var html = "<span  class='error'></br>(không bỏ trống)</span>";
        $("#TxtOrdTT").parent().append(html);
        flag = false;
    }
    //thuộc tính
    if (object.Idthuoctinh == null || object.Idthuoctinh == "") {
        var html = "<span  class='error'> (không bỏ trống)</span>";
        $("#Selectloaithuoctinh").parent().append(html);
        flag = false;
    }
    if (object.Idcapthuoctinh == null || object.Idcapthuoctinh == "") {
        var html = "<span  class='error'> (không bỏ trống)</span>";
        $("#Selectcapthuoctinh").parent().append(html);
        flag = false;
    }
    if (object.Text == null || object.Text == "") {
        var html = "<span  class='error'> (không bỏ trống)</span>";
        $("#TxtNameTT").parent().append(html);
        flag = false;
    }
    if (object.Value == null || object.Value == "") {
        var html = "<span  class='error'> (không bỏ trống)</span>";
        $("#TxtValueTT").parent().append(html);
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
                url: "/Quanlywebsite/DientuThuoctinhAdmin/Update",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0 || data == 3) {
                        if (data == 1) {
                            // alert_Insert(); //thông báo
                            window.setTimeout(function () {
                                getloadthuoctinh($("#TxtId").val());
                                cancelTT();
                            }, 500)
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


function InsertMain() {
    var filter = window.location.search.substring(1); //lấy giá trị request url
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        Seri: $("#TxtSeri").val(),
        Tenhang: $("#TxtTenhang").val(),
        Tag:"",
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
        Forder: "",

        Baiviet: CKEDITOR.instances['TxtBaiviet'].getData(),
        Thongso: "",

        Mota: "",//vị trí loại
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

        Index: "0",
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
    //console.log(object);
    //return false;
    // đưa giá trị actice chek

    object.Tag = change_alias(object.Tenhang);

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
                    if (data == 1 || data == 0 || data == 3) {
                        if (data == 1) {
                            Get_Read_Tag(object.Tag); //load data
                            //var idid = $("#TxtId").val();
                            //insertTT();
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
    return flag;

}


function cancelTT()
{
    $("#IdTagTT").val("");
    $("#TxtNameTT").val("");
    $("#TxtValueTT").val("");
    $("#TxtSoluongCH").val("1");
    $("#TxtOrdTT").val("");
}
