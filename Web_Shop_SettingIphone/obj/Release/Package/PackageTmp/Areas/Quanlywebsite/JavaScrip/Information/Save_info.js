$(document).ready(function () {
   
    $("#Save").click(function () { // khi nhấn lệnh lưu
        
        Upadte();
       
        return false;
    });
});

//load jaavscrip đầu vào
$(document).ready(function () {

   // $("#update_paner").css("display", "none");
    get_Read(3); //gọi hàm get dữ liệu
});


//xử lý sự kiện hình ảnh

$("#SelectImage").blur(function () { //sự kiện khi rời vị trí đối tượng
    $("#imgShowScren").attr("src", $("#TxtImage").val());
    var img = $("#imgShowScren").attr("src"); // lấy giá trị
    if (img == "" || img == null) { //nếu null
        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
    }
});

$("#imgShowScren").click(function () { // sự kiện khi click lên ảnh

    $("#imgShowScren").attr("src", $("#TxtImage").val()); // lấy ảnh giá trị biến Id
    var img = $("#imgShowScren").attr("src"); // lấy giá trị
    if (img == "" || img == null) { //nếu null
        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
    }

});

//implementted the action click in active
$("#CKActive").click(function () {

    if ($("#CKActive").attr('checked')) {
        $("#CKActive").removeAttr('checked');
        $("#CKActive").val("0");
    }
    else {
        $("#CKActive").attr('checked', 'checked');
        $("#CKActive").val("1");
    }
});