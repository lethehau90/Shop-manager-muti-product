
//load jaavscrip đầu vào
$("#update_paner").css("display", "none");
$("#update_paner_rep").css("display", "none");

//soạn chỉnh sửa
$(".view").click(function () {
    var action = $(this); // khởi tạo hành động
    var Id = action.data('id');
    get_Read(Id); //gọi hàm get dữ liệu
    //star loading
    $("body").addClass("loading");
    setTimeout(function () {

        $("#update_paner").css("display", "block"); //hiển thị panner
        $("#update_paner_rep").css("display", "none");
        get_Read(Id); //gọi hàm get dữ liệu

        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);

        $("body").removeClass("loading");  //end loading

    }, 500);


    return false;

});

//soạn chỉnh sửa
$(".Rep").click(function () {
    var action = $(this); // khởi tạo hành động
    var IdProduct = action.data('idproduct');
    var Id = action.data('id');
    get_Read_Rep(IdProduct,Id); //gọi hàm get dữ liệu
    //star loading
    $("body").addClass("loading");
    setTimeout(function () {

        $("#update_paner").css("display", "none"); //hiển thị panner
        $("#update_paner_rep").css("display", "block");
        get_Read_Rep(IdProduct,Id); //gọi hàm get dữ liệu

        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner_rep").offset().top
        }, 500);

        $("body").removeClass("loading");  //end loading

    }, 500);


    return false;

});


