$(document).ready(function () {
    
    $("#functiongiagiam").click(function () {
        var phantramkhuyenmai = $("#TxtPhantramkhuyenmai").val();
        var Giabankhuyenmai = $("#TxtGiabankhuyenmai").val().replace(",", "").replace(",", "");
        var Giaban = $("#TxtGiaban").val().replace(",", "").replace(",", "");
        var flag = true;
        $(".error").remove();
        if (phantramkhuyenmai == "")
        {
            var html = "<span class='error'>% giảm giá chưa nhập</span>";
            $(".TxtPhantramkhuyenmai").html(html);
            flag = false;
        }
        else
        {
            var price = Giaban * ((100 - phantramkhuyenmai) / 100);
            $("#TxtGiabankhuyenmai").val(formatMoneyVND(price))

        }
        return flag;
    });

    $("#TxtPhantramkhuyenmai").blur(function () {
        var phantramkhuyenmai = $("#TxtPhantramkhuyenmai").val();
        var Giabankhuyenmai = $("#TxtGiabankhuyenmai").val().replace(",", "").replace(",", "");
        var Giaban = $("#TxtGiaban").val().replace(",", "").replace(",", "");
        var flag = true;
        $(".error").remove();
        if (phantramkhuyenmai == "") {
            var html = "<span class='error'>% giảm giá chưa nhập</span>";
            $(".TxtPhantramkhuyenmai").html(html);
            flag = false;
        }
        else {
            var price = Giaban * ((100 - phantramkhuyenmai) / 100);
            $("#TxtGiabankhuyenmai").val(formatMoneyVND(price))

        }
        return flag;
    });

    //blur khi rời khỏi focus
    $("#TxtGiaban").blur(function () {
        var phantramkhuyenmai = $("#TxtPhantramkhuyenmai").val();
        var Giabankhuyenmai = $("#TxtGiabankhuyenmai").val().replace(",", "").replace(",", "");
        var Giaban = $("#TxtGiaban").val().replace(",", "").replace(",", "");
        var flag = true;
        $(".error").remove();
        if (phantramkhuyenmai == "") {
            var html = "<span class='error'>% giảm giá chưa nhập</span>";
            $(".TxtPhantramkhuyenmai").html(html);
            flag = false;
        }
        else {
            var price = Giaban * ((100 - phantramkhuyenmai) / 100);
            $("#TxtGiabankhuyenmai").val(formatMoneyVND(price))

        }
        return flag;
    });

});