$(document).ready(function () {
   
    $("#Save").click(function () { // khi nhấn lệnh lưu
        
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
});

//load jaavscrip đầu vào
$(document).ready(function () {

    $("#update_paner").css("display", "none");

    $(".Edit").click(function () {

        var action = $(this); // khởi tạo hành động
        var Id = action.data('id');

        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
           
            $("#update_paner").css("display", "block"); //hiển thị panner

            get_Read(Id); //gọi hàm get dữ liệu

            //trượt tới vị trí panner
            $('html, body').animate({
                scrollTop: $("#update_paner").offset().top
            }, 500);

            $("body").removeClass("loading");  //end loading

        }, 500  );
       
        
        return false;
        
    });

    $("#Insert").click(function () {

        $("#update_paner").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            Id: $("#TxtId").val(),
            Name: $("#TxtName").val(),
            Username: $("#TxtUsername").val(),
            Password: $("#TxtPassword").val(),
            ConfirmPassword: $("#TxtConfirmPassword").val(),
            Ord: $("#TxtOrd").val(),
            Active: ""
        };

        $.each(object, function (key, item) { //process delete
            $("#Txt" + key).val("");
            $("#TxtOrd").val("1");
            $("#CKActive").val("1");
        });
        $('#SelectRole option').removeAttr('selected').filter('[value=Personnel]').attr('selected', true);
        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);
        return false;
    });
});

