﻿$(document).ready(function () {
   
    $("#Save").click(function () { // khi nhấn lệnh lưu
        //xóa thông tin header

        var Id = $("#TxtId").val();
        if (Id == "")
        {
            Insert();
        }
        else
        {
            Upadte();
        }
        return false;
    });

    $("#Save_lever").click(function () {
        var Id = $("#TxtlevelId").val();
        if (Id == "") {
            Insert();
        }
        else {
            Upadte_lever2();
        }
        return false;

    });

    //xử lý thêm mới cấp độ 2
    $("#Save_add").click(function () {
        Insert_lever2();

        return false;
    });

    //xử lý sự kiện hình ảnh

    //$("#TxtLogogroup").blur(function () { //sự kiện khi rời vị trí đối tượng
    //    $("#imgShowScren").attr("src", $("#TxtLogogroup").val());
    //    var img = $("#imgShowScren").attr("src"); // lấy giá trị
    //    if (img == "" || img == null) { //nếu null
    //        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
    //    }
    //});

    //$("#imgShowScren").click(function () { // sự kiện khi click lên ảnh

    //    $("#imgShowScren").attr("src", $("#TxtLogogroup").val()); // lấy ảnh giá trị biến Id
    //    var img = $("#imgShowScren").attr("src"); // lấy giá trị
    //    if (img == "" || img == null) { //nếu null
    //        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
    //    }
    //});
    // end xử lý sự kiện hình ảnh


    //sự kiện click ảnh cho phần cấp độ 3
    //$("#TxtlevelLogogroup").blur(function () { //sự kiện khi rời vị trí đối tượng
    //    $("#imgShowScrenlevel").attr("src", $("#TxtlevelLogogroup").val());
    //    var img = $("#imgShowScrenlevel").attr("src"); // lấy giá trị
    //    if (img == "" || img == null) { //nếu null
    //        $("#imgShowScrenlevel").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
    //    }
    //});

    //$("#imgShowScrenlevel").click(function () { // sự kiện khi click lên ảnh
    //    $("#imgShowScrenlevel").attr("src", $("#TxtlevelLogogroup").val()); // lấy ảnh giá trị biến Id
    //    var img = $("#imgShowScrenlevel").attr("src"); // lấy giá trị
    //    if (img == "" || img == null) { //nếu null
    //        $("#imgShowScrenlevel").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
    //    }
    //});

    //sự kiện click ảnh cho phần thêm cấp độ 2
    //$("#TxtaddLogogroup").blur(function () { //sự kiện khi rời vị trí đối tượng
    //    $("#imgShowScrenAdd").attr("src", $("#TxtaddLogogroup").val());
    //    var img = $("#imgShowScrenAdd").attr("src"); // lấy giá trị
    //    if (img == "" || img == null) { //nếu null
    //        $("#imgShowScrenAdd").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
    //    }
    //});

    //$("#imgShowScrenAdd").click(function () { // sự kiện khi click lên ảnh

    //    $("#imgShowScrenAdd").attr("src", $("#TxtaddLogogroup").val()); // lấy ảnh giá trị biến Id
    //    var img = $("#imgShowScren").attr("src"); // lấy giá trị
    //    if (img == "" || img == null) { //nếu null
    //        $("#imgShowScrenAdd").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
    //    }
    //});
});

//load jaavscrip đầu vào
$("#update_paner").css("display", "none");
$("#update_panerlever").css("display", "none");
$("#update_paner_add").css("display", "none");

//thêm dữ liệu
$("#Insert").click(function () {
    $("#Selectlevel").removeAttr('disabled');
    $("span.Editcatelog").text("mới");
    $("#update_paner").css("display", "block");//hiển thị panner
    $("#update_panerlever").css("display", "none");
    $("#update_paner_add").css("display", "none");
    var object = { //khai báo các giá trị xóa trống
        TxtId: $("#TxtId").val(),
        TxtName: $("#TxtName").val(),
        Txtcontent: $("#Txtcontent").val(),
        TxtOrd: $("#TxtOrd").val(),
        
        CKActive: ""
    };

    $.each(object, function (key, item) { //process delete
        $("#" + key).val("");
    });
    $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
    $("#TxtOrd").val("1");
    $("#CKActive").val("1");

    $('#Selectlevel option').removeAttr('selected').filter('[value=""]').attr('selected', true);

    //trượt tới vị trí panner
    $('html, body').animate({
        scrollTop: $("#update_paner").offset().top
    }, 500);
    return false;
});


//thêm dữ liệu cấp độ 2
$("#Insert_2").click(function () {
    //$("#Selectlevel").removeAttr('disabled');
    $("span.Editcatelog").text("mới");

    $("#update_paner_add").css("display", "block");//hiển thị panner
    $("#update_panerlever").css("display", "none");
    $("#update_paner").css("display", "none");

    var object = { //khai báo các giá trị xóa trống
        TxtaddId: $("#TxtaddId").val(),
        TxtaddName: $("#TxtaddName").val(),
        Txtaddcontent: $("#Txtaddcontent").val(),
        TxtaddOrd: $("#TxtaddOrd").val(),

        CKaddActive: ""
    };

    $.each(object, function (key, item) { //process delete
        $("#" + key).val("");
    });
    $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
    $("#TxtaddOrd").val("1");
    $("#CKaddActive").val("1");

    $('#Selectlevel option').removeAttr('selected').filter('[value=""]').attr('selected', true);

    //trượt tới vị trí panner
    $('html, body').animate({
        scrollTop: $("#update_paner_add").offset().top
    }, 500);
    return false;
});


$(document).ready(function () {
    //chạy click treeclick
    $('#treeclick').tree({
        onClick: function (node) {
            // alert(node.text);
        }
    });

   
    //soạn chỉnh sửa
    $(".Edit").click(function () {
       
        //  $("#Selectlevel").prop("disabled", true);
        var action = $(this); // khởi tạo hành động
        var Id = action.data('id');
        get_Read(Id); //gọi hàm get dữ liệu
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {

            $("#update_paner").css("display", "block"); //hiển thị panner
            $("#update_panerlever").css("display", "none");
            $("#update_paner_add").css("display", "none");
            get_Read(Id); //gọi hàm get dữ liệu

            //trượt tới vị trí panner
            $('html, body').animate({
                scrollTop: $("#update_paner").offset().top
            }, 500);

            $("body").removeClass("loading");  //end loading

        }, 500);


        ////load ddd= list

       

        return false;

    });
});


$(document).ready(function () {
    //chạy click treeclick
    $('#treeclick').tree({
        onClick: function (node) {
            // alert(node.text);
        }
    });
    //soạn chỉnh sửa
    $(".Editlever2").click(function () {

        //  $("#Selectlevel").prop("disabled", true);
        var action = $(this); // khởi tạo hành động
        var Id = action.data('id');
        get_Read_lever(Id); //gọi hàm get dữ liệu
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {

            $("#update_panerlever").css("display", "block"); //hiển thị panner
            $("#update_paner").css("display", "none");
            $("#update_paner_add").css("display", "none");

            get_Read(Id); //gọi hàm get dữ liệu

            //trượt tới vị trí panner
            $('html, body').animate({
                scrollTop: $("#update_panerlever").offset().top
            }, 500);

            $("body").removeClass("loading");  //end loading

        }, 500);


        ////load ddd= list



        return false;

    });
});
