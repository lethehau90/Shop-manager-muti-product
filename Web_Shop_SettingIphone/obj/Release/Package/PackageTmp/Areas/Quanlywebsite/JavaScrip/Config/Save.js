$(document).ready(function () {
   
    $("#Save").click(function () { // khi nhấn lệnh lưu
        
        Upadte();
       
        return false;
    });
});

//load jaavscrip đầu vào
$(document).ready(function () {

   // $("#update_paner").css("display", "none");
    get_Read(1); //gọi hàm get dữ liệu
});


//xử lý sự kiện hình ảnh

$("#TxtIcon").blur(function () { //sự kiện khi rời vị trí đối tượng
    $("#imgShowScren").attr("src", $("#TxtIcon").val());
    var img = $("#imgShowScren").attr("src"); // lấy giá trị
    if (img == "" || img == null) { //nếu null
        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
    }
});

$("#imgShowScren").click(function () { // sự kiện khi click lên ảnh

    $("#imgShowScren").attr("src", $("#TxtIcon").val()); // lấy ảnh giá trị biến Id
    var img = $("#imgShowScren").attr("src"); // lấy giá trị
    if (img == "" || img == null) { //nếu null
        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
    }

});

